using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInterface : MonoBehaviour
{
    private Quaternion rot = Quaternion.Euler(0, 0, 0);
    private GameObject place;
    private Transform pos;

    public GameObject GameMaster;
    public bool tabOpen;

    GameObject Description;
    GameObject Level;
    GameObject LevelText;

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

    public int code;


    public new string tag;

    public void Start()
    {
        GameMaster = GameObject.FindGameObjectWithTag("GM");

        Description = GameObject.FindGameObjectWithTag("Descriptiontab");
        Level = GameObject.FindGameObjectWithTag("Leveltab");
        LevelText = GameObject.FindGameObjectWithTag("Texttab");

        House1Sprite = GameObject.FindGameObjectWithTag("House1tab");
        House2Sprite = GameObject.FindGameObjectWithTag("House2tab");
        Barrack1Sprite = GameObject.FindGameObjectWithTag("Barracks1tab");
        Barrack2Sprite = GameObject.FindGameObjectWithTag("Barracks2tab");
        //b3
        Farm1Sprite = GameObject.FindGameObjectWithTag("Farm1tab");
        Farm2Sprite = GameObject.FindGameObjectWithTag("Farm2tab");
        //f3
        Shop1Sprite = GameObject.FindGameObjectWithTag("Shop1tab");
        Shop2Sprite = GameObject.FindGameObjectWithTag("Shop2tab");
        //s3
        Library1Sprite = GameObject.FindGameObjectWithTag("Library1tab");
        //l2
        //l3
        Factory1Sprite = GameObject.FindGameObjectWithTag("Factory1tab");
        //f2
        //f3
        //mines123
    }

    public void OnMouseDown()
    {
        GameMaster.GetComponent<BaseUI>().BuildingInterface();
        GameMaster.GetComponent<BuildingInterface>().code = code;  //Moving code place from individual building to gamemaster so, can be used to manipulate the buildable places

        if (tabOpen == false)
        {
            GameMaster.GetComponent<BaseUI>().buildingInterface = true;
            tag = gameObject.tag;
            GameMaster.GetComponent<BaseUI>().selected = gameObject;
            Level.GetComponent<Text>().enabled = true;
            Description.GetComponent<Text>().enabled = true;
            LevelText.GetComponent<Text>().enabled = true;
            //GameMaster.GetComponent<BaseUI>().BuildingInterface();

            GameMaster.GetComponent<BaseUI>().tab.GetComponent<Image>().enabled = true;
            GameMaster.GetComponent<BaseUI>().upgrade.GetComponent<Image>().enabled = true;
            GameMaster.GetComponent<BaseUI>().demolish.GetComponent<Image>().enabled = true;
            GameMaster.GetComponent<BaseUI>().line.GetComponent<Text>().enabled = false;

            if (tag == "House1")
            {    
                Level.GetComponent<Text>().text = "1";
                Description.GetComponent<Text>().text = "Increases Army Capacity               5 / 10 / 20";
                House1Sprite.GetComponent<Image>().enabled = true;
            }
            else if (tag == "House2")
            {
                Level.GetComponent<Text>().text = "2";
                Description.GetComponent<Text>().text = "Increases Army Capacity               5 / 10 / 20";
                House2Sprite.GetComponent<Image>().enabled = true;
            }
            else if (tag == "House3")
            {
                Level.GetComponent<Text>().text = "3";
                Description.GetComponent<Text>().text = "Increases Army Capacity               5 / 10 / 20";
                //House3Sprite
            }
            else if (tag == "Barracks1")
            {
                Level.GetComponent<Text>().text = "1";
                Description.GetComponent<Text>().text = "Be able to train units";
                Barrack1Sprite.GetComponent<Image>().enabled = true;
            }
            else if (tag == "Barracks2")
            {
                Level.GetComponent<Text>().text = "2";
                Description.GetComponent<Text>().text = "Be able to train units";
                Barrack2Sprite.GetComponent<Image>().enabled = true;
            }
            else if (tag == "Barracks3")
            {
                Level.GetComponent<Text>().text = "3";
                Description.GetComponent<Text>().text = "Be able to train units";
                //Barrack3Sprite
            }
            else if (tag == "Farm1")
            {
                Level.GetComponent<Text>().text = "1";
                Description.GetComponent<Text>().text = "Produces food               2 / 10 / 50";
                Farm1Sprite.GetComponent<Image>().enabled = true;
            }
            else if (tag == "Farm2")
            {
                Level.GetComponent<Text>().text = "2";
                Description.GetComponent<Text>().text = "Produces food               2 / 10 / 50";
                Farm2Sprite.GetComponent<Image>().enabled = true;
            }
            else if (tag == "Farm3")
            {
                Level.GetComponent<Text>().text = "3";
                Description.GetComponent<Text>().text = "Produces food               2 / 10 / 50";
                //Farm3Sprite
            }
            else if (tag == "Shop1")
            {
                Level.GetComponent<Text>().text = "1";
                Description.GetComponent<Text>().text = "Produces gold                1 / 5 / 25";
                Shop1Sprite.GetComponent<Image>().enabled = true;
            }
            else if (tag == "Shop2")
            {
                Level.GetComponent<Text>().text = "2";
                Description.GetComponent<Text>().text = "Produces gold                 1 / 5 / 25";
                Shop2Sprite.GetComponent<Image>().enabled = true;
            }
            else if (tag == "Shop3")
            {
                Level.GetComponent<Text>().text = "3";
                Description.GetComponent<Text>().text = "Produces gold                 1 / 5 / 25";
                //Shop3Sprite
            }
            else if (tag == "Library1")
            {
                Level.GetComponent<Text>().text = "1";
                Description.GetComponent<Text>().text = "Reduces Training Time               1% / 3% / 7%";
                Library1Sprite.GetComponent<Image>().enabled = true;
            }
            else if (tag == "Library2")
            {
                Level.GetComponent<Text>().text = "1";
                Description.GetComponent<Text>().text = "Reduces Training Time               1% / 3% / 7%";
                //Library2Sprite
            }
            else if (tag == "Library3")
            {
                Level.GetComponent<Text>().text = "3";
                Description.GetComponent<Text>().text = "Reduces Training Time               1% / 3% / 7%";
                //Library3Sprite
            }
            else if (tag == "Factory1")
            {
                Level.GetComponent<Text>().text = "1";
                Description.GetComponent<Text>().text = "Produces Electronics               0.2 / 0.5 / 1";
                Factory1Sprite.GetComponent<Image>().enabled = true;
            }
            else if (tag == "Factory2")
            {
                Level.GetComponent<Text>().text = "2";
                Description.GetComponent<Text>().text = "Produces Electronics               0.2 / 0.5 / 1";
                //Factory2Sprite
            }
            else if (tag == "Factory3")
            {
                Level.GetComponent<Text>().text = "3";
                Description.GetComponent<Text>().text = "Produces Electronics               0.2 / 0.5 / 1";
                //Factory3Sprite
            }
            else if (tag == "Mine1")
            {
                Level.GetComponent<Text>().text = "1";
                Description.GetComponent<Text>().text = "Produces Stone                 1 / 10 / 100";
                //Mine1Sprite
            }
            else if (tag == "Mine2")
            {
                Level.GetComponent<Text>().text = "2";
                Description.GetComponent<Text>().text = "Produces Stone                 1 / 10 / 100";
                //Mine2Sprite
            }
            else if (tag == "Mine3")
            {
                Level.GetComponent<Text>().text = "3";
                Description.GetComponent<Text>().text = "Produces Stone                 1 / 10 / 100";
                //Mine3Sprite
            }

        } else
        {
            Close();
        }

    }
    private void Update()
    {
        tabOpen = GameMaster.GetComponent<BaseUI>().buildingInterface;
       // Debug.Log(code);
        //Debug.Log(place);
    }

    public void Close()
    {
        GameMaster.GetComponent<BaseUI>().buildingInterface = false;
        Description.GetComponent<Text>().enabled = false;
        Level.GetComponent<Text>().enabled = false;
        LevelText.GetComponent<Text>().enabled = false;
        House1Sprite.GetComponent<Image>().enabled = false;
        House2Sprite.GetComponent<Image>().enabled = false;
        //House3Sprite.GetComponent<Image>().enabled = false;
        Barrack1Sprite.GetComponent<Image>().enabled = false;
        Barrack2Sprite.GetComponent<Image>().enabled = false;
        //Barrack3Sprite.GetComponent<Image>().enabled = false;
        Farm1Sprite.GetComponent<Image>().enabled = false;
        Farm2Sprite.GetComponent<Image>().enabled = false;
        //Farm3Sprite.GetComponent<Image>().enabled = false;
        Shop1Sprite.GetComponent<Image>().enabled = false;
        Shop2Sprite.GetComponent<Image>().enabled = false;
        //Shop3Sprite.GetComponent<Image>().enabled = false;
        Library1Sprite.GetComponent<Image>().enabled = false;
        //Library2Sprite.GetComponent<Image>().enabled = false;
        //Library3Sprite.GetComponent<Image>().enabled = false;
        Factory1Sprite.GetComponent<Image>().enabled = false;
        //Factory2Sprite.GetComponent<Image>().enabled = false;
        //Factory3Sprite.GetComponent<Image>().enabled = false;
        //Mine1Sprite.GetComponent<Image>().enabled = false;
        //Mine2Sprite.GetComponent<Image>().enabled = false;
        //Mine3Sprite.GetComponent<Image>().enabled = false;

        GameMaster.GetComponent<BaseUI>().tab.GetComponent<Image>().enabled = false;
        GameMaster.GetComponent<BaseUI>().upgrade.GetComponent<Image>().enabled = false;
        GameMaster.GetComponent<BaseUI>().demolish.GetComponent<Image>().enabled = false;
        GameMaster.GetComponent<BaseUI>().line.GetComponent<Text>().enabled = false;

    }

    public void Upgrade()
    {
        if (GameMaster.GetComponent<BaseUI>().selected.CompareTag("House1"))
        {
            Instantiate(GameMaster.GetComponent<BaseBuilding>().House2, GameMaster.GetComponent<BaseUI>().selected.transform.position, rot).GetComponent<BuildingInterface>().code = GameMaster.GetComponent<BaseUI>().selected.GetComponent<BuildingInterface>().code;
            Destroy(GameMaster.GetComponent<BaseUI>().selected);
            GameMaster.GetComponent<PlayerAccount>().house1--;
            GameMaster.GetComponent<PlayerAccount>().house2++;
            OnMouseDown();
        }
        if (GameMaster.GetComponent<BaseUI>().selected.CompareTag("Farm1"))
        {
            Instantiate(GameMaster.GetComponent<BaseBuilding>().Farm2, GameMaster.GetComponent<BaseUI>().selected.transform.position, rot).GetComponent<BuildingInterface>().code = GameMaster.GetComponent<BaseUI>().selected.GetComponent<BuildingInterface>().code;
            Destroy(GameMaster.GetComponent<BaseUI>().selected);
            GameMaster.GetComponent<PlayerAccount>().farm1--;
            GameMaster.GetComponent<PlayerAccount>().farm2++;
            OnMouseDown();
        }
        if (GameMaster.GetComponent<BaseUI>().selected.CompareTag("Barracks1"))
        {
            Instantiate(GameMaster.GetComponent<BaseBuilding>().Barracks2, GameMaster.GetComponent<BaseUI>().selected.transform.position, rot).GetComponent<BuildingInterface>().code = GameMaster.GetComponent<BaseUI>().selected.GetComponent<BuildingInterface>().code;
            Destroy(GameMaster.GetComponent<BaseUI>().selected);
            GameMaster.GetComponent<PlayerAccount>().barracks1--;
            GameMaster.GetComponent<PlayerAccount>().barracks2++;
            OnMouseDown();
        }
        if (GameMaster.GetComponent<BaseUI>().selected.CompareTag("Shop1"))
        {
            Instantiate(GameMaster.GetComponent<BaseBuilding>().Shop2, GameMaster.GetComponent<BaseUI>().selected.transform.position, rot).GetComponent<BuildingInterface>().code = GameMaster.GetComponent<BaseUI>().selected.GetComponent<BuildingInterface>().code;
            Destroy(GameMaster.GetComponent<BaseUI>().selected);
            GameMaster.GetComponent<PlayerAccount>().shop1--;
            GameMaster.GetComponent<PlayerAccount>().shop2++;
            OnMouseDown();
        }
    }

    public void Demolish()
    {
        place = GameObject.Find("Positions");
        Debug.Log(code.ToString());
        
        foreach (Transform child in place.transform)
        {

            if (code.ToString() == child.name)
            {
                Debug.Log("yeet1");
                child.GetComponent<BuildablePlaces>().Revert();
            }           
        }

        Destroy(GameMaster.GetComponent<BaseUI>().selected);
    }
}

    