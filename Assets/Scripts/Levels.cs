using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public int levelNumber = 1;
    GameObject wavespawner;
    List<int> waveList = new List<int>();

    private void Start()
    {
        wavespawner = GameObject.FindGameObjectWithTag("WaveSpawner");
        Level();
    }

    public void Level()
    {
        if (levelNumber == 1)
        {
            waveList = new List<int>() { 0, 0, 0, 1, 1 };
        } else if (levelNumber == 2)
        {
            waveList = new List<int>() { 0, 0, 0, 0, 0, 1, 1, 1, 0, 1 };
        }

        wavespawner.GetComponent<WaveSpawner>().Spawn(waveList);
    }

}
