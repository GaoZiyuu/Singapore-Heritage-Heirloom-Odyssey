/* Author: Leong YenZhen
 * Date: 22/12/2023
 * Description: Script to make tour boat move
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    /// <summary>
    /// platform
    /// </summary>
    PlatformMoving platform;

    /// <summary>
    /// move when start
    /// </summary>
    private void Start()
    {
        platform = GetComponent<PlatformMoving>();
    }

    /// <summary>
    /// when triggered, boat can move
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        platform.canMove = true;
    }
}
