using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public float timeBetweenSpawns = 1f;
    public GameObject enemy0;
    public GameObject enemy1;

    public void Spawn(List<int> wave)
    {
        StartCoroutine(Spawner());
        IEnumerator Spawner()
        {
            for (int i = 0; i < wave.Count; i++)
            {
                if (wave[i] == 0)
                {
                    Instantiate(enemy0);
                } else if (wave[i] == 1)
                {
                    Instantiate(enemy1);
                }
                yield return new WaitForSeconds(timeBetweenSpawns);

            }
        }
       
    }
}
