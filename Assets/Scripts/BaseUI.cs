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
    public bool buildingInterface = true;

    public GameObject selected;

    public GameObject tab;
    public GameObject stats;
    public GameObject build;
    public GameObject buildButtons;
    public GameObject positions;
    public GameObject line;
    public GameObject upgrade;
    public GameObject demolish;

    GameObject House1Sprite;
    GameObject House2Sprite;
    GameObject Barrack1Sprite;
    GameObject Barrack2Sprite;
    GameObject Farm1Sprite;
    GameObject Farm2Sprite;
    GameObject Shop1Sprite;
    GameObject Shop2Sprite;
    GameObject Library1Sprite;
    GameObject Factory1Sprite;

    private float timePercentageReduction;

    // Start is called before the first frame update
    void Start()
    {
        StatsButton();
        BuildButton();
        BuildingInterface();

        House1Sprite = GameObject.FindGameObjectWithTag("House1tab");
        House1Sprite.GetComponent<Image>().enabled = false;
        House2Sprite = GameObject.FindGameObjectWithTag("House2tab");
        House2Sprite.GetComponent<Image>().enabled = false;
        //h3
        Barrack1Sprite = GameObject.FindGameObjectWithTag("Barracks1tab");
        Barrack1Sprite.GetComponent<Image>().enabled = false;
        Barrack2Sprite = GameObject.FindGameObjectWithTag("Barracks2tab");
        Barrack2Sprite.GetComponent<Image>().enabled = false;
        //b3
        Farm1Sprite = GameObject.FindGameObjectWithTag("Farm1tab");
        Farm1Sprite.GetComponent<Image>().enabled = false;
        Farm2Sprite = GameObject.FindGameObjectWithTag("Farm2tab");
        Farm2Sprite.GetComponent<Image>().enabled = false;
        //f3
        Shop1Sprite = GameObject.FindGameObjectWithTag("Shop1tab");
        Shop1Sprite.GetComponent<Image>().enabled = false;
        Shop2Sprite = GameObject.FindGameObjectWithTag("Shop2tab");
        Shop2Sprite.GetComponent<Image>().enabled = false;
        //s3
        Library1Sprite = GameObject.FindGameObjectWithTag("Library1tab");
        Library1Sprite.GetComponent<Image>().enabled = false;
        //l2
        //l3
        Factory1Sprite = GameObject.FindGameObjectWithTag("Factory1tab");
        Factory1Sprite.GetComponent<Image>().enabled = false;
        //f2
        //f3
        //mines123 // tabs need to be added too
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
        gameObject.GetComponent<BuildingInterface>().Close();
    }
    public void StatsButton()
    {
        if (statsTab == false) {
            if (buildTab || buildingInterface)
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
            if (statsTab || buildingInterface)
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

    public void BuildingInterface()
    {

        buildingInterface = false;
        tab.GetComponent<Image>().enabled = false;
        line.GetComponent<Text>().enabled = false;
        upgrade.GetComponent<Image>().enabled = false;
        demolish.GetComponent<Image>().enabled = false;

        if (statsTab || buildTab || upgradeTab)
        {
            CloseAll();
        }
    }
}
