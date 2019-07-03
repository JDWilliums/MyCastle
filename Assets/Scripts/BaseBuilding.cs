using System.Collections;
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
            Instantiate(House, pos, rot);
        } else if (selected == 2)
        {
            Instantiate(Barracks, pos, rot);
        } else if (selected == 3)
        {
            Instantiate(Farm, pos, rot);
        } else if (selected == 4)
        {
            Instantiate(Shop, pos, rot);
        } else if (selected == 5)
        {
            Instantiate(Library, pos, rot);
        } else if (selected == 6)
        {
            Instantiate(Factory, pos, rot);
        }
    }
}
