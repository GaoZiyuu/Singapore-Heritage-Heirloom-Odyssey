using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKopi : MonoBehaviour
{
    public GameObject kopiMaker;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kopiMaker")
        {
            Destroy(other.gameObject);
            kopiMaker.SetActive(true);
        }
        
    }
}
