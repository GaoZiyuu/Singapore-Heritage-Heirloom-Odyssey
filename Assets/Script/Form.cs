using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Unity.UI;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Analytics;

public class Form : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField messageInputField;
    [SerializeField] private TMP_InputField ageInputField;
    [SerializeField] private TMP_InputField genderInputField;


    private DatabaseReference databaseReference;

    private void Start()
    {
        // Initialize Firebase
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void SubmitFormFromButton()
    {
        SubmitForm();
    }

    public void SubmitForm()
    {
        string name = nameInputField.text;
        string email = emailInputField.text;
        string message = messageInputField.text;
        string age = ageInputField.text;
        string gender = genderInputField.text;

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