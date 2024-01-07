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

    public void ToPast()
    {
        SceneManager.LoadScene(SceneData.past);
    }

    public void ToEnd()
    {
        SceneManager.LoadScene(SceneData.End);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(SceneData.Auth);
    }

    public void ToQuit()
    {
        Application.Quit();
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ToPast();
            Debug.Log("teleported");
        }
    }
}
