using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE:
// This script assumes that the only children of the attached GameObject will be these prefabs,
// there are no debugs to enforce this yet.

public class Respawner : MonoBehaviour
{
    
    // Defines the rectangle in which objects may spawn
    public Vector2 boundsOne = new Vector2(-10, -10), boundsTwo = new Vector2(10, 10);
    public GameObject respawnPrefab;
    public int instancesAtOnce = 1;
    public float freeSpaceRadius = 2;
    // Recursion limit for findFreeSpace() calls
    public int freeSpaceTries = 10;

    private Vector3? FindFreeSpace()
    {
        for (int i = 0; i < freeSpaceTries; i++)
        {
            Vector3 randomPoint;
            randomPoint.x = Random.Range(Mathf.Min(boundsOne.x, boundsTwo.x), Mathf.Max(boundsOne.x, boundsTwo.x));
            randomPoint.y = Random.Range(Mathf.Min(boundsOne.y, boundsTwo.y), Mathf.Max(boundsOne.y, boundsTwo.y));
            randomPoint.z = 0; // we're in 2D

            if (!Physics2D.OverlapCircle(randomPoint, freeSpaceRadius))
            {
                return randomPoint;
            }
        }

        return null;
    }
    void AttemptSpawn()
    { 
        Vector3? spawnLocation = FindFreeSpace();
        if (spawnLocation == null)
        {
            Debug.Log("Out of tries!"); 
            GameObject[] holeObjects = GameObject.FindGameObjectsWithTag("breakThrough");
            if (holeObjects.Length > 0)
            {
                Destroy(holeObjects[Random.Range(0, holeObjects.Length)]);
            }
        }
        else
        {
            GameObject instantiatedPrefab = Instantiate(respawnPrefab, spawnLocation.Value, Quaternion.identity, transform);
        }
    }

    void FixedUpdate()
    {
        while (transform.childCount < instancesAtOnce)
            AttemptSpawn();
    }
}
