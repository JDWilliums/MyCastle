using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildablePlaces : MonoBehaviour
{
    // A weird class to act as a button for buildable places, used to store place and position data
    Vector3 pos;
    public int code;

    public GameObject GameMaster;
    private void Start()
    {
        //
    }
    private void OnMouseDown()
    {
        if (GameMaster.GetComponent<BaseBuilding>().selected != 0)
        {
            pos = gameObject.transform.position;

            // Right so, the reason why i did this was to differentiate the building places being used
            // to building places not used. When i close the building tab this was undifferentiatable
            // so i basically did the same thing to the used places just differently so they dont get changed
            // within the code in basebuilding.cs 
            var tempColor = gameObject.GetComponent<SpriteRenderer>().color;
            tempColor.a = 0f;
            gameObject.GetComponent<SpriteRenderer>().color = tempColor;

            var tempSize = gameObject.GetComponent<BoxCollider2D>().size;
            tempSize = new Vector3(0, 0);
            gameObject.GetComponent<BoxCollider2D>().size = tempSize;

            GameMaster.GetComponent<BaseBuilding>().InstantiatingBuilding(code, pos);
        }
    }
    public void Revert()
    {
        var tempColor = gameObject.GetComponent<SpriteRenderer>().color;
        tempColor.a = 1f;
        gameObject.GetComponent<SpriteRenderer>().color = tempColor;
        Debug.Log("yeet");

        var tempSize = gameObject.GetComponent<BoxCollider2D>().size;
        tempSize = new Vector3(32, 32);
        gameObject.GetComponent<BoxCollider2D>().size = tempSize;
    }
}
