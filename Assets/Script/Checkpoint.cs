using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public Material myMaterial;
    public GameObject myCheckPointManager;
    private bool rickshawOn;

    private void Start()
    {
        rickshawOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player" && rickshawOn)
        {
            myMaterial.color = Color.green;
            myCheckPointManager.GetComponent<CheckPointManager>().checkPointCounter++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && rickshawOn)
        {
            myMaterial.color = Color.white;
        }
    }

    public void rickshawCheck()
    {
        rickshawOn = !rickshawOn;
    }

    private void Update()
    {
        if(myCheckPointManager.GetComponent<CheckPointManager>().checkPointCounter == 4)
        {
            rickshawCheck();
        }
    }
}
