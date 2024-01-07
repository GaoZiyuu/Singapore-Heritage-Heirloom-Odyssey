/* Author: Gao Ziyu
 * Date: 01/01/2024
 * Description: Script to submit form data
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Analytics;

public class Form : MonoBehaviour
{
    /// <summary>
    /// variables
    /// </summary>
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField messageInputField;
    [SerializeField] private TMP_InputField ageInputField;
    [SerializeField] private TMP_InputField genderInputField;

    /// <summary>
    /// database reference
    /// </summary>
    private DatabaseReference databaseReference;

    private void Start()
    {
        // Initialize Firebase
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    /// <summary>
    /// submit button 
    /// </summary>
    public void SubmitFormFromButton()
    {
        SubmitForm();
    }
    
    /// <summary>
    /// submit function
    /// </summary>
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
  
    /// <summary>
    /// data to submit
    /// </summary>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="message"></param>
    /// <param name="age"></param>
    /// <param name="gender"></param>
    public FormSubmissionData(string name, string email, string message, string age, string gender)
    {
        this.name = name;
        this.email = email;
        this.message = message;
        this.age = age;
        this.gender = gender;
       
    }
}