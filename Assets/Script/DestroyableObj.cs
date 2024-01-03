using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObj : MonoBehaviour
{
    public ObjectRespawner respawner;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "teaSet") // Assuming the object is destroyed by a projectile
        {
            Destroy(gameObject); // Destroy the object

            // Respawn the object after a delay of 3 seconds
            respawner.RespawnObject(3f);
        }
    }
}
