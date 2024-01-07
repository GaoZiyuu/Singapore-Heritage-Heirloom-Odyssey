/* Author: Gao Ziyu
 * Date: 01/01/2024 
 * Description: Kopi animations & interactions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakingKopi : MonoBehaviour
{
    /// <summary>
    /// animator
    /// </summary>
    public Animator kopiPowderPour;
    public Transform MakeKopi;

    public Animator hotWaterPour;

    public Animator stir;

    /// <summary>
    /// game objects
    /// </summary>
    public GameObject kopiPowder;
    public GameObject hotWater;
    public GameObject scooper;

    /// <summary>
    /// animation played when enters trigger box
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kopiPowder")
        {
            kopiPowder.SetActive(true);
            kopiPowderPour.SetBool("kopiPour", true);
            other.transform.SetParent(MakeKopi);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "hotWater")
        {
            hotWater.SetActive(true);
            hotWaterPour.SetBool("hotpour", true);
            other.transform.SetParent(MakeKopi);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "scooper")
        {
            scooper.SetActive(true);
            stir.SetBool("stir", true);
            other.transform.SetParent(MakeKopi);
            Destroy(other.gameObject);
        }
    }
}
