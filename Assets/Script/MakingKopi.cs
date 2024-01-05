using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingKopi : MonoBehaviour
{
    public Animator kopiPowderPour;
    public Transform MakeKopi;

    public Animator hotWaterPour;

    public Animator stir;

    public GameObject kopiPowder;
    public GameObject hotWater;
    public GameObject scooper;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kopiPowder")
        {
            kopiPowder.SetActive(true);
            //kopiPowderPour.SetBool("kopiPour", true);
            other.transform.SetParent(MakeKopi);
            StartCoroutine(hideKopiPowder());
        }

        if (other.gameObject.tag == "hotWater")
        {
            hotWater.SetActive(true);
            //hotWaterPour.SetBool("hotpour", true);
            other.transform.SetParent(MakeKopi);
            StartCoroutine(hideHotWater());
        }

        if (other.gameObject.tag == "scooper")
        {
            scooper.SetActive(true);
            //stir.SetBool("stir", true);
            other.transform.SetParent(MakeKopi);
            StartCoroutine(hideScooper());
        }
    }

    IEnumerator hideKopiPowder()
    {
        kopiPowderPour.SetBool("kopiPour", true);
        yield return new WaitForSeconds(3);
        kopiPowder.SetActive(false);
    }

    IEnumerator hideHotWater()
    {
        hotWaterPour.SetBool("hotpour", true);
        yield return new WaitForSeconds(3);
        hotWater.SetActive(false);
    }

    IEnumerator hideScooper()
    {
        stir.SetBool("stir", true);
        yield return new WaitForSeconds(3);
        scooper.SetActive(false);
    }
}
