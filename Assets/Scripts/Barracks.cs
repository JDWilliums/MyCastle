using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    GameObject brawler; // code 0
    GameObject infantry; // 1
    GameObject archer; // 2
    GameObject cavalry; // 3
    GameObject knight; // 4
    GameObject captain; // 5
    GameObject medic; // 6
    GameObject gamemaster;

    public float trainTimeConstant;

    public float trainTime;

    public float totalTime;

    List<int> trainingQ = new List<int>() {0,0,0,1,5};

    private void Start()
    {
        gamemaster = GameObject.FindGameObjectWithTag("GM");
        
        TrainingQueue(trainingQ);
    }
    private void Update()
    {
        trainTimeConstant = gamemaster.GetComponent<PlayerAccount>().barracksTimeConstant;
    }

    void TrainingQueue(List<int> trainingQ)
    {

        trainTimeConstant = gamemaster.GetComponent<PlayerAccount>().barracksTimeConstant;
        StartCoroutine(Train());

        for (int j = 0; j < trainingQ.Count; j++) // for loop for estimated time for queue
        {
            if (trainingQ[j] == 0)
            {
                totalTime += 30f;
            } else if (trainingQ[j] == 1)
            {
                totalTime += 90f;
            }
            else if (trainingQ[j] == 2)
            {
                totalTime += 60f;
            }
            else if (trainingQ[j] == 3)
            {
                totalTime += 150f;
            }
            else if (trainingQ[j] == 4)
            {
                totalTime += 180f;
            }
            else if (trainingQ[j] == 5)
            {
                totalTime += 300f;
            }
            else if (trainingQ[j] == 6)
            {
                totalTime += 120f;
            }
        }
        totalTime = totalTime / (1 + trainTimeConstant);

        IEnumerator Train() {
            for (int i = 0; i < trainingQ.Count; i++)
            {
                if (trainingQ[i] == 0)
                {
                    trainTime = (30f / (1f + trainTimeConstant));
                    yield return new WaitForSeconds(trainTime);
                    gamemaster.GetComponent<PlayerAccount>().numBrawler += 1;
                    Debug.Log("added brawler");
                }
                else if (trainingQ[i] == 1)
                {
                    trainTime = 90f / (1f + trainTimeConstant);
                    yield return new WaitForSeconds(trainTime);
                    gamemaster.GetComponent<PlayerAccount>().numInfantry += 1;
                    Debug.Log("added infantry");
                }
                else if (trainingQ[i] == 2)
                {
                    trainTime = 60f / (1f + trainTimeConstant);
                    yield return new WaitForSeconds(trainTime);
                    gamemaster.GetComponent<PlayerAccount>().numArcher += 1;
                }
                else if (trainingQ[i] == 3)
                {
                    trainTime = 150f / (1f + trainTimeConstant);
                    yield return new WaitForSeconds(trainTime);
                    gamemaster.GetComponent<PlayerAccount>().numCavalry += 1;
                }
                else if (trainingQ[i] == 4)
                {
                    trainTime = 180f / (1f + trainTimeConstant);
                    yield return new WaitForSeconds(trainTime);
                    gamemaster.GetComponent<PlayerAccount>().numKnight += 1;
                }
                else if (trainingQ[i] == 5)
                {
                    trainTime = 300f / (1f + trainTimeConstant);
                    yield return new WaitForSeconds(trainTime);
                    gamemaster.GetComponent<PlayerAccount>().numCaptain += 1;
                    Debug.Log("added captain");
                }
                else if (trainingQ[i] == 6)
                {
                    trainTime = 120f / (1f + trainTimeConstant);
                    yield return new WaitForSeconds(trainTime);
                    gamemaster.GetComponent<PlayerAccount>().numMedic += 1;
                }
            }
            
        }
    }
}
