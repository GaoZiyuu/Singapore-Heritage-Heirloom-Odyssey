/* Author: Gao Ziyu
 * Date: 24/12/2023
 * Description:To control the scenes to go to when interacted or triggered
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// to past scene
    /// </summary>
    public void ToPast()
    {
        SceneManager.LoadScene(SceneData.past);
    }

    /// <summary>
    /// to end scene
    /// </summary>
    public void ToEnd()
    {
        SceneManager.LoadScene(SceneData.End);
    }

    /// <summary>
    /// to menu scene
    /// </summary>
    public void ToMenu()
    {
        SceneManager.LoadScene(SceneData.Auth);
    }

    /// <summary>
    /// quit game
    /// </summary>
    public void ToQuit()
    {
        Application.Quit();
    }


    /// <summary>
    /// teleport player to past scene when triggered
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ToPast();
            Debug.Log("teleported");
        }
    }
}
