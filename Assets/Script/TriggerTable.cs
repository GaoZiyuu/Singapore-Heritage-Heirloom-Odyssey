using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTable : MonoBehaviour
{
    public GameObject teaPlate;
    public GameObject teaCup;
    public GameObject teaSpoon;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "kopiPlate")
        {
            Destroy(teaPlate.gameObject);
            teaPlate.SetActive(true);
        }
        if(other.gameObject.tag == "kopiCup")
        {
            Destroy(teaCup.gameObject);
            teaCup.SetActive(true);
        }
        if(other.gameObject.tag == "spoon")
        {
            Destroy(teaSpoon.gameObject);
            teaSpoon.SetActive(true);
        }
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
