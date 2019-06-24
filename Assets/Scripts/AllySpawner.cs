using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    public Transform spawnFrom;
    public GameObject ally;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Spawn();
            Debug.Log("spawning");
        }
    }
    public void Spawn()
    {
        Instantiate(ally);
    }
}
