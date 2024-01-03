using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    public GameObject objectPrefab; // The prefab of the object to respawn
    public Transform respawnPoint; // The position to respawn the object

    // Example method to respawn the object after a delay
    public void RespawnObject(float delay)
    {
        Invoke("Respawn", delay);
    }

    private void Respawn()
    {
        // Instantiate a new object at the respawn point
        GameObject newObject = Instantiate(objectPrefab, respawnPoint.position, respawnPoint.rotation);
        // Optionally set the parent of the new object
        newObject.transform.parent = transform.parent; // Set the parent to the same parent as the original object, if needed
    }
}
