using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSandBag : MonoBehaviour
{
    public GameObject SandBag1;
    public GameObject SandBag2;
    public GameObject SandBag3;
    public int bagtracker;
    public GameObject relic;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sandbag")
         
        {
            bagtracker += 1;

            if (other.gameObject.tag == "sandbag" && bagtracker == 1)
            {
                Destroy(other.gameObject);
                SandBag1.SetActive(true);
            }

            else if (other.gameObject.tag == "sandbag" && bagtracker == 2)
            {
                Destroy(other.gameObject);
                SandBag2.SetActive(true);
            }

            else if (other.gameObject.tag == "sandbag" && bagtracker == 3)
            {
                Destroy(other.gameObject);
                SandBag3.SetActive(true);
                relic.SetActive(true);
            }
        }
        
        

        /*if (other.gameObject.tag == "sandbag1")

        {
            Destroy(other.gameObject);
            SandBag1.SetActive(true);

        }*/

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
