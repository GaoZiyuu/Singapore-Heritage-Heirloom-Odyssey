using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
   public Material myMaterial;
   
    
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
           myMaterial.color = Color.green;
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
