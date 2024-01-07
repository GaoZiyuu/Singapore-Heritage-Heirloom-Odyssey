/* Author: Leong YenZhen
 * Date: 22/12/2023
 * Description: Script to parent player to boat
 */
using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPlatform : MonoBehaviour
{
    /// <summary>
    /// rigidbody
    /// </summary>
    public Rigidbody rb;

    /// <summary>
    /// when player collide into boat, set boat as parent to player so player moves with the boat
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(transform);
            rb.velocity = new Vector2(0, 0);
            Debug.Log("worked");

        }


    }

    /// <summary>
    /// remove from parent when not in collision box
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
