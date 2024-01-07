
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// function to change scene
    /// </summary>
    /// <param name="sceneName"></param>
    public void NextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }



}