/* 
 * Author : Pang Le Xin
 * Date: 01/01/2024
 * Description: Checkpoint for dda
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    /// <summary>
    /// variables for materials
    /// </summary>
    public Material myMaterial;
    /// <summary>
    /// gameobject variables
    /// </summary>
    public GameObject myCheckPointManager;
   

    /// <summary>
    /// on trigger enter
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player" )
        {
            //myCheckPointManager.GetComponent<CheckPointManager>().AddCollidedObjNames(other.gameObject.name);
            //myMaterial.color = Color.green;
            myCheckPointManager.GetComponent<CheckPointManager>().checkPointCounter++;
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// on trigger exit
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //myMaterial.color = Color.white;
        }
    }

}
