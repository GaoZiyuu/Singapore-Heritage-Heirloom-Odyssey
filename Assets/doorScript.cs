using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "key")
        {
            Debug.Log("Door is open");
            animator.SetBool("isOpen", true);
        }
      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "key")
        {
            Debug.Log("Door is closed");
            animator.SetBool("isOpen", false);
        }
        

    }
}
