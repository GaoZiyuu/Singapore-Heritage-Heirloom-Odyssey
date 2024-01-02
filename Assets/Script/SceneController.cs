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

    public void LPS_int()
    {
        SceneManager.LoadScene(SceneData.LPS_Int);
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
