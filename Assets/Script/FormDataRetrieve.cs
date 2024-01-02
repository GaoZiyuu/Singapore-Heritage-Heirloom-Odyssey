using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormDataRetrieve : MonoBehaviour
{
    public InputField nameInputField;
    public InputField emailInputField;
    public InputField messageInputField;
    public InputField ageInputField;
    public InputField genderInputField;

    public void GetFormData()
    {
        string name = nameInputField.text;
        string email = emailInputField.text;
        string message = messageInputField.text;
        string age = ageInputField.text;
        string gender = genderInputField.text;

        Form formSubmission = GetComponent<Form>();
        formSubmission.SubmitForm(name, email, message, age, gender);
    }
}
