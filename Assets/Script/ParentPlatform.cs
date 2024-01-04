using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlatform : MonoBehaviour
{
    public Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(transform);
            rb.velocity = new Vector2(0, 0);
            Debug.Log("worked");

        }


    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
