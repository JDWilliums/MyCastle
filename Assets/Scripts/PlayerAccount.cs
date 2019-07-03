using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccount : MonoBehaviour
{
    // Resources and buildings
    public float gold = 0;
    public float food = 0;
    public float stone = 0;
    public float electronics;
    public float armyCapacity;
    public float armyCount;

    public float house1 = 0;
    public float house2 = 0;
    public float house3 = 0;

    public float farm1 = 0;
    public float farm2 = 0;
    public float farm3 = 0;

    public float quarry1 = 0;
    public float quarry2 = 0;
    public float quarry3 = 0;

    public float factory1 = 0;
    public float factory2 = 0;
    public float factory3 = 0;

    public float barracks1 = 0;
    public float barracks2 = 0;
    public float barracks3 = 0;

    public float library1 = 0;
    public float library2 = 0;
    public float library3 = 0;

    public float shop1 = 0;
    public float shop2 = 0;
    public float shop3 = 0;

    // Statistics
    public float castleLevel = 0;
    public float waveLevel = 0;

    public float goldps; // gold per second
    public float foodps; // food per second
    public float barracksTimeConstant; //A constant that changes the training time of troops, can be changed with researching through libraries.
    public float stoneps;
    public float electronicsps;

    // Troops
    public float numBrawler;
    public float numInfantry;
    public float numArcher;
    public float numCavalry;
    public float numKnight;
    public float numCaptain;
    public float numMedic;

    // Building array
    public int[] buildingArray1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };

    private void Update()
    {
        goldps = shop1 * 1f + shop2 * 5f + shop3 * 25f;
        foodps = farm1 * 2f + farm2 * 10f + farm3 * 50f;
        electronicsps = factory1 * 0.2f + factory2 * 0.5f + factory3 * 1f;
        barracksTimeConstant = library1 * 0.1f + library2 * 0.3f + library3 * 0.7f;
        stoneps = quarry1 * 1f + quarry2 * 10f + quarry3 * 100f;
        armyCapacity = 25f + house1 * 5f + house2 * 10f + house3 * 20f;
        armyCount = numBrawler * 5 + numInfantry * 5 + numArcher * 3 + numCavalry * 3 + numKnight * 2 + numCaptain * 1 + numMedic * 2; // add when queued to check
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
            stone += stoneps;
            electronics += electronicsps;
            yield return new WaitForSeconds(1f);
        }
        
    }
}
