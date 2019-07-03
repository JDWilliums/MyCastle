using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildablePlaces : MonoBehaviour
{
    // A weird class to act as a button for buildable places, used to store place and position data
    Vector3 pos;
    public int code;

    public GameObject GameMaster;
    private void OnMouseDown()
    {
        pos = gameObject.transform.position;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameMaster.GetComponent<BaseBuilding>().InstantiatingBuilding(code,pos);
    }
}
