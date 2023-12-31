using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("worked");
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.SetParent(null);
    }
}
