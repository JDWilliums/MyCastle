using System.Collections;
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
    private bool buildTab = false;
    private bool upgradeTab = false;

    public GameObject tab;
    public GameObject stats;


    // Start is called before the first frame update
    void Start()
    {
        StatsButton();

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

    public void StatsButton()
    {
        if (statsTab == false) {
            statsTab = true;
            tab.GetComponent<Image>().enabled = true;
            stats.GetComponentInChildren<Text>().enabled = true;
            foreach (Transform child in stats.transform)
            {
                child.GetComponent<Text>().enabled = true;
            }
        } else
        {
            statsTab = false;
            tab.GetComponent<Image>().enabled = false;
            stats.GetComponentInChildren<Text>().enabled = false;
            foreach (Transform child in stats.transform)
            {
                child.GetComponent<Text>().enabled = false;
            }
            
        }
    }
}
