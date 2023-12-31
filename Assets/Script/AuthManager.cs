using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using Firebase.Database;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    /// <summary>
    /// Firebase variables
    /// </summary>
    [Header("Firebase")] // header to be shown in inspector
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    

    /// <summary>
    /// Login variables
    /// </summary>
    [Header("Login")] // header to be shown in inspector
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText; // text that shows up when there is a error logging in
    public TMP_Text confirmLoginText; // text to inform user that they have successfully log in



    /// <summary>
    /// Register variables
    /// </summary>
    [Header("Register")] // header to be shown in inspector
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText; // text that shows up when there is a error
    public TMP_Text registerLoginText; // text to inform user that they have successfully created an account and logged in

    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });

        // Create sample user data
        
    }

    public void GoToSurvey()
    {
        SceneManager.LoadScene(SceneData.End);
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;       
    }

    public void LoginButton()
    {
        //Call the login coroutine and passing the email and password
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }
    //Function for the register button
    public void RegisterButton()
    {
        //Call the register coroutine  and passing the email, password, username
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text));
    }

    private IEnumerator Login(string _email, string _password)
    {
        //Pass to firebase the email and password
        Task<AuthResult> LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        //if there is an error completing the above task
        if (LoginTask.Exception != null)
        {
            //Check for errors and handles it
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            //make use of TMP_Text warning text to inform user what is the error
            string message = "Login Failed!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Missing Email";
                    break;
                case AuthError.MissingPassword:
                    message = "Missing Password";
                    break;
                case AuthError.WrongPassword:
                    message = "Wrong Password";
                    break;
                case AuthError.InvalidEmail:
                    message = "Invalid Email";
                    break;
                case AuthError.UserNotFound:
                    message = "Account does not exist";
                    break;
            }
            warningLoginText.text = message;
        }
        else
        {
            //User have successfully logged in
            User = LoginTask.Result.User;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = ""; //to reset warning text

            GoToSurvey();
            confirmLoginText.text = "Logged In";

        }
    }

    /// <summary>
    /// similar to login, passes email,password,username to firebase, register panel
    /// </summary>
    /// <param name="_email"></param>
    /// <param name="_password"></param>
    /// <param name="_username"></param>
    /// <returns></returns>
    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "") // if username is empty/not filled
        {
            //missing username warning message will pop up
            warningRegisterText.text = "Missing Username";
        }
        //if password doesnt match
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            //warning message will pop up to inform user that the password doesnt match
            warningRegisterText.text = "Password Does Not Match!";
        }
        else
        {
            //Call the Firebase auth sign in function passing the email and password
            //firebase will create a new user
            Task<AuthResult> RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            //if there is error completing the above task
            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                //make use of TMP_Text warning text to inform user what is the error
                string message = "Register Failed!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Missing Email";
                        break;
                    case AuthError.MissingPassword:
                        message = "Missing Password";
                        break;
                    case AuthError.WeakPassword:
                        message = "Weak Password";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Email Already In Use";
                        break;
                }
                warningRegisterText.text = message;
            }
            else
            {
                //User account has been created
                User = RegisterTask.Result.User;

                if (User != null)
                {
                    //create a user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    //call the Firebase auth update user profile function passing the profile with the username
                    Task ProfileTask = User.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        //Check for errors and handles it
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {

                        //account is set and user can log in
                        //thus change back to login screen to allow user to log in 
                        //UIManager.instance.LoginScreen();
                        warningRegisterText.text = ""; //reset warning text
                        registerLoginText.text = "Account Created and Logging In...";
                        

                    }
                }
            }
        }

    }
}
