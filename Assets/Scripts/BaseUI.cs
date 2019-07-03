﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUI : MonoBehaviour
{
    public Text statsGPS;
    public Text statsFPS;
    public Text statsAC;
    public Text statsTR;

    private bool statsTab = true; // Actually false just easier to call statsbutton to turn in false
    private bool buildTab = true;
    private bool upgradeTab = false;

    public GameObject tab;
    public GameObject stats;
    public GameObject build;
    public GameObject buildButtons;
    public GameObject positions;
    public GameObject line;

    // Start is called before the first frame update
    void Start()
    {
        StatsButton();
        BuildButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (statsTab)
        {
            statsGPS.text = GetComponent<PlayerAccount>().goldps.ToString();
            statsFPS.text = GetComponent<PlayerAccount>().foodps.ToString();
            statsAC.text = GetComponent<PlayerAccount>().armyCapacity.ToString();
            statsTR.text = GetComponent<PlayerAccount>().barracksTimeConstant.ToString(); // needs to change to percentage
            // Add army count or army = army count / army capacity
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
            }
        } else
        {
            buildTab = false;
            line.GetComponent<Text>().enabled = false;
            tab.GetComponent<Image>().enabled = false;

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
            }
        }
    }
}
