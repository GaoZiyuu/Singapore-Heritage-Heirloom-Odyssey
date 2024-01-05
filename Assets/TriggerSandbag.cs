using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSandbag : MonoBehaviour
{
    public GameObject sandbag1;
    public GameObject sandbag2;
    public GameObject sandbag3;
    public GameObject relic;
    public int bagtracker;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sandbag")
        {
            bagtracker += 1;

            if (bagtracker == 1 && other.gameObject.tag == "sandbag")
            {
                Destroy(other.gameObject);
                sandbag1.SetActive(true);
            }
            else if (bagtracker == 2 && other.gameObject.tag == "sandbag")
            {
                Destroy(other.gameObject);
                sandbag2.SetActive(true);
            }

            else if (bagtracker == 3 && other.gameObject.tag == "sandbag")
            {
                Destroy(other.gameObject);
                sandbag3.SetActive(true);
            }


        }

        // Start is called before the first frame update
        void Start()
        {
            bagtracker = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
