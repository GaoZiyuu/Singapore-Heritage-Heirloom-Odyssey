/* Author: Gao Ziyu
 * Date: 06/01/2024
 * Description: To set active the kopi maker
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerKopi : MonoBehaviour
{
    /// <summary>
    /// game object
    /// </summary>
    public GameObject kopiMaker;

    /// <summary>
    /// set active gameobject when on trigger
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "kopiMaker")
        {
            Destroy(other.gameObject);
            kopiMaker.SetActive(true);
        }
        
    }
}
