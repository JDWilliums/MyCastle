using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccount : MonoBehaviour
{
    public float gold = 0;
    public float food = 0;
    public float armyCapacity;

    public float farm1 = 0;
    public float farm2 = 0;
    public float farm3 = 0;

    public float quarry1 = 0;
    public float quarry2 = 0;
    public float quarry3 = 0;

    public float factory1 = 0;
    public float factory2 = 0;
    public float factory3 = 0;

    public float training1 = 0;
    public float training2 = 0;
    public float training3 = 0;

    public float library1 = 0;
    public float library2 = 0;
    public float library3 = 0;

    public float shop1 = 0;
    public float shop2 = 0;
    public float shop3 = 0;

    public float castleLevel = 0;

    public float goldps; // gold per second
    public float foodps; // food per second
    public float trainingTimeConstant; //A constant that changes the training time of troops, can be changed with researching through libraries.

    private void Update()
    {
        goldps = shop1 * 1f + shop2 * 5f + shop3 * 25f;
        foodps = farm1 * 2f + farm2 * 10f + farm3 * 50f;
        trainingTimeConstant = library1 * 1.1f + library2 * 1.3f + library3 * 1.7f;

    
    }

    private void Start()
    {
        Accumulator();
    }


    private void Accumulator()
    {
        StartCoroutine("Accum");
    }

    IEnumerator Accum()
    {
        while(true) { 
            gold += goldps;
            food += foodps;
            Debug.Log(gold + " gold");
            Debug.Log(food + " food");

            yield return new WaitForSeconds(1f);
            }
        
    }
}
