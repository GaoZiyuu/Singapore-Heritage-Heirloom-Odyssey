using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public Material myMaterial;
    public GameObject myCheckPointManager;
   


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player" && myCheckPointManager.GetComponent<CheckPointManager>().rickshawOn == true)
        {
            myMaterial.color = Color.green;
            myCheckPointManager.GetComponent<CheckPointManager>().checkPointCounter++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && myCheckPointManager.GetComponent<CheckPointManager>().rickshawOn == true)
        {
            myMaterial.color = Color.white;
        }
    }

}
