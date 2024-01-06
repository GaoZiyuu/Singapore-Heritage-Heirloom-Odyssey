using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKopi : MonoBehaviour
{
    public Animator conMilk;
    public Transform teaSet;

    public Animator pourKopi;

    public GameObject conMilky;
    public GameObject doneKopi;
    public GameObject condenseMilk;
    public GameObject kopi;

    public GameObject endInstruction;
    public GameObject Auntie;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "condenseMilk")
        {
            conMilky.SetActive(true);
            conMilk.SetBool("Pour", true);
            other.transform.SetParent(teaSet);
            Destroy(other.gameObject);
            condenseMilk.SetActive(true);
        }

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
