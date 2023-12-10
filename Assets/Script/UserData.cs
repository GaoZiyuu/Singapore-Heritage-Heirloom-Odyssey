using UnityEngine;
using System;
using Firebase;
using Firebase.Database;
using Firebase.Auth;

//THIS IS TO TEST CREATE Sample data
public class UserData : MonoBehaviour
{
    private FirebaseAuth auth;
    private DatabaseReference databaseReference;

    void Start()
    {
        // Initialize Firebase Auth and Database
        InitializeFirebase();

        // Create sample user data
        CreateUser("ziyu@gmail.com", "1234567", 20);
        CreateUser("yenzhen@gmail.com", "1234567", 19);
        CreateUser("lexin@gmail.com", "1234567", 18);
    }

    void InitializeFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                auth = FirebaseAuth.DefaultInstance;
                databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                Debug.Log("Firebase initialized successfully!");
            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            }
        });
    }

    void CreateUser(string email, string username, int age)
    {
        // Create a new user
        auth.CreateUserWithEmailAndPasswordAsync(email, "password123").ContinueWith(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                Debug.LogError("Failed to create user.");
                return;
            }

            // Get the Firebase User
            FirebaseUser newUser = task.Result.User;

            // Save user data to the Firebase Realtime Database
            if (newUser != null)
            {
                User userData = new User(username, age);
                string json = JsonUtility.ToJson(userData);
                databaseReference.Child("users").Child(newUser.UserId).SetRawJsonValueAsync(json)
                    .ContinueWith(databaseTask =>
                    {
                        if (databaseTask.IsFaulted)
                        {
                            Debug.LogError("Failed to save user data to database: " + databaseTask.Exception);
                        }
                        else if (databaseTask.IsCompleted)
                        {
                            Debug.Log("User data saved successfully!");
                        }
                    });
            }
        });
    }
}

[Serializable]
public class User
{
    public string username;
    public int age;

    public User(string username, int age)
    {
        this.username = username;
        this.age = age;
    }
}