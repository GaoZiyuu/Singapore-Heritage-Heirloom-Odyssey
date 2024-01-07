/* 
 * Author : Gao Ziyu
 * Date: 29/12/2023
 * Description: Script to make the kopi animation works
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKopi : MonoBehaviour
{
    /// <summary>
    /// variables for animator
    /// </summary>
    public Animator conMilk;
    /// <summary>
    /// variables for teaset
    /// </summary>
    public Transform teaSet;
    /// <summary>
    /// variable for animator
    /// </summary>
    public Animator pourKopi;

    /// <summary>
    /// varitables for gameobjects
    /// </summary>
    public GameObject conMilky;
    public GameObject doneKopi;
    public GameObject condenseMilk;
    public GameObject kopi;

    public GameObject endInstruction;
    public GameObject Auntie;

    /// <summary>
    /// variables for ontriggerenter
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // collide into gameobject tag to trigger animations and other events
        if(other.gameObject.tag == "condenseMilk")
        {
            conMilky.SetActive(true);
            conMilk.SetBool("Pour", true);
            other.transform.SetParent(teaSet);
            Destroy(other.gameObject);
            condenseMilk.SetActive(true);
        }

        // collide into gameobject tag to trigger animations and other events
        if (other.gameObject.tag == "doneKopi")
        {
            doneKopi.SetActive(true);
            pourKopi.SetBool("donePour", true);
            other.transform.SetParent(teaSet);
            Destroy(other.gameObject);
            kopi.SetActive(true);
            endInstruction.SetActive(false);
            Auntie.SetActive(true);
        }
    }
}
