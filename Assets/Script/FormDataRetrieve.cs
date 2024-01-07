/* Author: Gao Ziyu
 * Date: 01/01/2024
 * Description: Script to retrieve form data
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormDataRetrieve : MonoBehaviour
{
    /// <summary>
    /// variables
    /// </summary>
    public TMP_InputField nameInputField;
    public TMP_InputField emailInputField;
    public TMP_InputField messageInputField;
    public TMP_InputField ageInputField;
    public TMP_InputField genderInputField;

    /// <summary>
    /// submit form data
    /// </summary>
    public void SubmitFormData()
    {
        string name = nameInputField.text;
        string email = emailInputField.text;
        string message = messageInputField.text;
        string age = ageInputField.text;
        string gender = genderInputField.text;

        Form formSubmission = GetComponent<Form>();
//        formSubmission.SubmitForm(name, email, message, age, gender);
    }
}
