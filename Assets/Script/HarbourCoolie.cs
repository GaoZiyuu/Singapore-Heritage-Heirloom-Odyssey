using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HarbourCoolie : MonoBehaviour
{
    public int bagtracker;



    












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
            Debug.Log(bagtracker);
        }

        /*if (other.gameObject.tag == "Q1Trigger")
        {
            if (StaffKey == false)
            {
                FindStaffKey.SetActive(true);
            }

            else
            {
                FindStaffKey.SetActive(false);
            }

        }

        if (other.gameObject.tag == "questThree")
        {
            if (sheet == false)
            {
                Quest2.SetActive(false);
                Quest3.SetActive(true);
            }

        }
        if (other.gameObject.tag == "Q5")
        {
            Quest4.SetActive(false);
            Quest5.SetActive(true);
        }

        if (other.gameObject.tag == "Q9")
        {
            if (diary == false)
            {
                Debug.Log("Q9" + other.gameObject.name);
                Quest8.SetActive(false);
                Quest9.SetActive(true);
            }

        }*/


    }
}
