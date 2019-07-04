using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    public Text statsGPS;
    public Text statsFPS;
    public Text statsACap;
    public Text statsTR;
    public Text statsSPS;
    public Text statsEPS;
    public Text statsACount;

    private bool statsTab = true; // Actually false just easier to call statsbutton to turn in false
    private bool buildTab = true;
    private bool upgradeTab = false;

    public GameObject tab;
    public GameObject stats;
    public GameObject build;
    public GameObject buildButtons;
    public GameObject positions;
    public GameObject line;

    private float timePercentageReduction;

    // Start is called before the first frame update
    void Start()
    {
        StatsButton();
        BuildButton();
    }

    // Update is called once per frame
    void Update()
    {
        timePercentageReduction = GetComponent<PlayerAccount>().barracksTimeConstant * 10;
        if (statsTab)
        {
            statsGPS.text = GetComponent<PlayerAccount>().goldps.ToString();
            statsFPS.text = GetComponent<PlayerAccount>().foodps.ToString();
            statsACap.text = GetComponent<PlayerAccount>().armyCapacity.ToString();
            statsTR.text = timePercentageReduction.ToString();
            statsSPS.text = GetComponent<PlayerAccount>().stoneps.ToString();
            statsEPS.text = GetComponent<PlayerAccount>().electronicsps.ToString();
            statsACount.text = GetComponent<PlayerAccount>().armyCount.ToString();
            // needs to change to percentage
            
        }

    }
    public void CloseAll()
    {
        line.GetComponent<Text>().enabled = false;
        tab.GetComponent<Image>().enabled = false;
        statsTab = true; // set as true then runs switch code to set as false (ultimately turning off stats tab)
        StatsButton();
        buildTab = true;
        BuildButton();
    }
    public void StatsButton()
    {
        if (statsTab == false) {
            if (buildTab == true)
            {
                CloseAll();
            }
            statsTab = true;
            line.GetComponent<Text>().enabled = true;
            tab.GetComponent<Image>().enabled = true;
            foreach (Transform child in stats.transform)
            {
                child.GetComponent<Text>().enabled = true;
            }
        } else
        {
            statsTab = false;
            line.GetComponent<Text>().enabled = false;
            tab.GetComponent<Image>().enabled = false;
            foreach (Transform child in stats.transform)
            {
                child.GetComponent<Text>().enabled = false;
            }
            
        }
    }

    public void BuildButton()
    {
        if (buildTab == false)
        {
            if (statsTab == true)
            {
                CloseAll();
            }
            buildTab = true;
            line.GetComponent<Text>().enabled = true;
            tab.GetComponent<Image>().enabled = true;

            foreach (Transform child in build.transform)
            {
                child.GetComponent<Text>().enabled = true;
            }

            foreach (Transform child in buildButtons.transform)
            {
                child.GetComponent<Image>().enabled = true;
            }
            foreach (Transform child in positions.transform)
            {
                child.GetComponent<SpriteRenderer>().enabled = true;
                child.GetComponent<BoxCollider2D>().enabled = true;
                
            }
        } else
        {
            buildTab = false;
            line.GetComponent<Text>().enabled = false;
            tab.GetComponent<Image>().enabled = false;
            gameObject.GetComponent<BaseBuilding>().selected = 0;

            foreach (Transform child in build.transform)
            {
                child.GetComponent<Text>().enabled = false;
            }

            foreach (Transform child in buildButtons.transform)
            {
                child.GetComponent<Image>().enabled = false;
            }

            foreach (Transform child in positions.transform)
            {
                child.GetComponent<SpriteRenderer>().enabled = false;
                child.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
