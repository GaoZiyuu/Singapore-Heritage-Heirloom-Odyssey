using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("worked");
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(transform);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
