using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Unity.UI;
using TMPro;

public class Form : MonoBehaviour
{
    DatabaseReference databaseReference;

    public TMP_InputField nameInputField;
    public TMP_InputField emailInputField;
    public TMP_InputField messageInputField;

    // Start is called before the first frame update
    void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SubmitForm(string name, string email, string message, string age, string gender)
    {
        string name = nameInputField.text;
        string email = emailInputField.text;
        string message = messageInputField.text;

        // Create a unique key for each form submission
        string submissionKey = databaseReference.Child("submissions").Push().Key;

        // Create a data object with form values
        FormSubmissionData formData = new FormSubmissionData(name, email, message, age, gender);

        // Convert form data to JSON
        string json = JsonUtility.ToJson(formData);

        // Store form data in the database under the 'submissions' node
        databaseReference.Child("submissions").Child(submissionKey).SetRawJsonValueAsync(json)
            .ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Form submitted successfully!");
                }
                else if (task.IsFaulted)
                {
                    Debug.LogError("Error submitting form: " + task.Exception);
                }
            });
    }
}

// Data model for form submission
[System.Serializable]
public class FormSubmissionData
{
    public string name;
    public string email;
    public string message;
    public string age;
    public string gender;

    public FormSubmissionData(string name, string email, string message, string age, string gender)
    {
        this.name = name;
        this.email = email;
        this.message = message;
        this.age = age;
        this.gender = gender;
    }
}