using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HarbourCoolie : MonoBehaviour
{
    public int bagtracker;
    public GameObject text;


    // Start is called before the first frame update
    void Start()
    {
        bagtracker = 0;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// When on trigger enter, event will occur
    /// </summary>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sandBag")
        {
            bagtracker += 1 ;
            text.SetActive(true);
            Debug.Log(bagtracker);
        }

    }
}
