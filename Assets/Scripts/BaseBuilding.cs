﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour
{
    public int castleStage = 1;

    private Quaternion rot = Quaternion.Euler(0, 0, 0);

    //codes
    int house = 1;
    int barracks = 2;
    int farm = 3;
    int shop = 4;
    int library = 5;
    int factory = 6;

    public GameObject House;
    public GameObject Farm;
    public GameObject Barracks;
    public GameObject Library;
    public GameObject Shop;
    public GameObject Factory;

    public GameObject House2;
    public GameObject Farm2;
    public GameObject Barracks2;
    public GameObject Library2;
    public GameObject Shop2;
    public GameObject Factory2;

    public int selected = 0;

    public void SelectedBuilding(int code)
    {
        selected = code;
    } 

    public void InstantiatingBuilding(int placeCode, Vector3 pos)
    {
        pos = pos + new Vector3 (0, 0, -1); //this just sets it in front of background
        if (selected == 1)
        {
            Instantiate(House, pos, rot).GetComponent<BuildingInterface>().code = placeCode;
            gameObject.GetComponent<PlayerAccount>().house1++;
        } else if (selected == 2)
        {
            Instantiate(Barracks, pos, rot).GetComponent<BuildingInterface>().code = placeCode;
            gameObject.GetComponent<PlayerAccount>().barracks1++;
        } else if (selected == 3)
        {
            Instantiate(Farm, pos, rot).GetComponent<BuildingInterface>().code = placeCode;
            gameObject.GetComponent<PlayerAccount>().farm1++;
        } else if (selected == 4)
        {
            Instantiate(Shop, pos, rot).GetComponent<BuildingInterface>().code = placeCode;
            gameObject.GetComponent<PlayerAccount>().shop1++;
        } else if (selected == 5)
        {
            Instantiate(Library, pos, rot).GetComponent<BuildingInterface>().code = placeCode;
            gameObject.GetComponent<PlayerAccount>().library1++;
        } else if (selected == 6)
        {
            Instantiate(Factory, pos, rot).GetComponent<BuildingInterface>().code = placeCode;
            gameObject.GetComponent<PlayerAccount>().factory1++;
        }
    }
}
