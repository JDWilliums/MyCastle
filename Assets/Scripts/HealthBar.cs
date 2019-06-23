using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {
        if (sizeNormalized < 0)
        {
            sizeNormalized = 0;
        }
        bar.transform.localScale = new Vector2(sizeNormalized, 1f);
    }
}
