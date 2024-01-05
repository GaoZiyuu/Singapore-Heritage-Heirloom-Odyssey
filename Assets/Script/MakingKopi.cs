using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingKopi : MonoBehaviour
{
    public Animator kopiPowderPour;
    public Transform MakeKopi;

    public GameObject kopiPowder;
    public GameObject hotWater;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "condenseMilk")
        {
            kopiPowderPour.SetBool("Pour", true);
            other.transform.SetParent(MakeKopi);
            Destroy(other.gameObject);
        }
    }
}
