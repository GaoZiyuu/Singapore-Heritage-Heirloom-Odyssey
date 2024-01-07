using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTable : MonoBehaviour
{
    public GameObject teaPlate;
    public GameObject teaCup;
    public GameObject teaSpoon;
    public GameObject animMilk;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "kopiPlate")
        {
            Destroy(other.gameObject);
            teaPlate.SetActive(true);
        }
        if(other.gameObject.tag == "kopiCup")
        {
            Destroy(other.gameObject);
            teaCup.SetActive(true);
        }
        if(other.gameObject.tag == "spoon")
        {
            Destroy(other.gameObject);
            teaSpoon.SetActive(true);
        }
        if(other.gameObject.tag == "condenseMilk")
        {
            Destroy(other.gameObject);
            animMilk.SetActive(true);
        }
    }
}
