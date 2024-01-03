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
       if(other.tag == "Player" )
        {
            myMaterial.color = Color.green;
            myCheckPointManager.GetComponent<CheckPointManager>().checkPointCounter++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            myMaterial.color = Color.white;
        }
    }

}
