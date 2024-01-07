/* 
 * Author : Gao Ziyu
 * Date: 06/01/2024
 * Description: animation event to destroy animated object after animation
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    /// <summary>
    /// destroy gameobj
    /// </summary>
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
