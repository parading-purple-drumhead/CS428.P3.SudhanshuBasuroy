using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChips : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 spawnPosition;
    void Start()
    {
        Debug.Log("Item Touched!!!!");
    }

    public void door_open()
    {
        Debug.Log("Triggered");
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
