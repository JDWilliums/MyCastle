﻿using System.Collections;
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

    public float barracks1 = 0;
    public float barracks2 = 0;
    public float barracks3 = 0;

    public float library1 = 0;
    public float library2 = 0;
    public float library3 = 0;

    public float shop1 = 0;
    public float shop2 = 0;
    public float shop3 = 0;

    public float castleLevel = 0;

    public float goldps; // gold per second
    public float foodps; // food per second
    public float barracksTimeConstant; //A constant that changes the training time of troops, can be changed with researching through libraries.


    public float numBrawler;
    public float numInfantry;
    public float numArcher;
    public float numCavalry;
    public float numKnight;
    public float numCaptain;
    public float numMedic;

    private void Update()
    {
        goldps = shop1 * 1f + shop2 * 5f + shop3 * 25f;
        foodps = farm1 * 2f + farm2 * 10f + farm3 * 50f;
        barracksTimeConstant = library1 * 0.1f + library2 * 0.3f + library3 * 0.7f;  
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
            Debug.Log(barracksTimeConstant);

            yield return new WaitForSeconds(1f);
        }
        
    }
}