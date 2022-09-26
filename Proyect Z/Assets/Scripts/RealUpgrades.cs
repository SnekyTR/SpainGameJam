using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RealUpgrades : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] upgrades;
    public ScriptableObject upgradeSelected1;
    public ScriptableObject upgradeSelected2;
    private GameObject upgrade1;
    [SerializeField]private GameObject upgrade2;
    private bool clicked1;
    private bool clicked2;
    private Image upgradeImage1;
    private Image upgradeImage2;

    private string stringdisabled;
    private string stringToEnable;
    private string stringToEnabl2;
    [SerializeField] private Sprite disabledSprite;

    ShipsSelector shipsSelector;
    private int upgrade;
    // Start is called before the first frame update
    private void Awake()
    {
        bool ESP;
        upgradeImage1 = GameObject.Find("Upgrade1Selected").GetComponent<Image>();
        if (GameObject.Find("Upgrade2Selected"))
        {
            upgradeImage2 = GameObject.Find("Upgrade2Selected").GetComponent<Image>();
            BossDefeated();
            ESP = true;
        }
        else
        {
            ESP = false;
        }
        for (int i = 0; i < upgrades.Length; i++)
        {
            Weapons upgrad = (Weapons)upgrades[i];
            if (upgrad.selected == true)
            {
                if (upgradeSelected1 == null)
                {
                    upgradeSelected1 = upgrades[i]; upgradeImage1.sprite = upgrad.artwork; print(upgrad.weapName);
                }
                else 
                { 
                    print("No es null");
                }
                if (ESP)
                {
                    if (upgradeSelected2 == null)
                    {
                        if (upgradeSelected1 != upgrad)
                        {
                            upgradeSelected2 = upgrades[i]; upgrad.selected = true; upgradeImage2.sprite = upgrad.artwork;
                        }
                    }
                }
            }
        }
    }
    void Start()
    {
        upgrade1 = GameObject.Find("Upgrade1");
        

        shipsSelector = GameObject.Find("SpaceShipZone").GetComponent<ShipsSelector>();


    }
    public void GetProgression(int progressionNumber)
    {
        if (progressionNumber == 1)
        {
            BossDefeated();
        }
    }
    public void UpgradeButton(int i)
    {
        if (i == 1)
        {
            if (clicked2) TurnOffUpgrade2();
            if (!clicked1)
            {
                LeanTween.move(upgrade1.transform.GetChild(0).gameObject, upgrade1.transform.GetChild(6).position, 0.5f);
                LeanTween.move(upgrade1.transform.GetChild(1).gameObject, upgrade1.transform.GetChild(7).position, 0.5f);
                LeanTween.move(upgrade1.transform.GetChild(2).gameObject, upgrade1.transform.GetChild(8).position, 0.5f);
                LeanTween.move(upgrade1.transform.GetChild(3).gameObject, upgrade1.transform.GetChild(9).position, 0.5f);
                LeanTween.move(upgrade1.transform.GetChild(4).gameObject, upgrade1.transform.GetChild(10).position, 0.5f);
                upgrade1.transform.GetChild(0).gameObject.SetActive(true);
                upgrade1.transform.GetChild(1).gameObject.SetActive(true);
                upgrade1.transform.GetChild(2).gameObject.SetActive(true);
                upgrade1.transform.GetChild(3).gameObject.SetActive(true);
                upgrade1.transform.GetChild(4).gameObject.SetActive(true);
                stringdisabled = stringdisabled + 1;
                print(stringdisabled);
                if (GameObject.Find(stringdisabled))
                {
                    GameObject.Find(stringdisabled).GetComponent<Button>().interactable = false;
                }
                if (stringToEnabl2 != null)
                {
                    stringToEnabl2 = stringToEnabl2 + 1;
                    if (GameObject.Find(stringToEnabl2))
                        {
                        GameObject.Find(stringToEnabl2).GetComponent<Button>().interactable = true;
                    }                   
                }
                clicked1 = true;
            }
            else
            {
                TurnOffUpgrade1();
            }
        }
        if (i == 2)
        {
            if (clicked1) TurnOffUpgrade1();
            if (!clicked2)
            {
                LeanTween.move(upgrade2.transform.GetChild(0).gameObject, upgrade2.transform.GetChild(6).position, 0.5f);
                LeanTween.move(upgrade2.transform.GetChild(1).gameObject, upgrade2.transform.GetChild(7).position, 0.5f);
                LeanTween.move(upgrade2.transform.GetChild(2).gameObject, upgrade2.transform.GetChild(8).position, 0.5f);
                LeanTween.move(upgrade2.transform.GetChild(3).gameObject, upgrade2.transform.GetChild(9).position, 0.5f);
                LeanTween.move(upgrade2.transform.GetChild(4).gameObject, upgrade2.transform.GetChild(10).position, 0.5f);
                upgrade2.transform.GetChild(0).gameObject.SetActive(true);
                upgrade2.transform.GetChild(1).gameObject.SetActive(true);
                upgrade2.transform.GetChild(2).gameObject.SetActive(true);
                upgrade2.transform.GetChild(3).gameObject.SetActive(true);
                upgrade2.transform.GetChild(4).gameObject.SetActive(true);
                stringdisabled = stringdisabled + 2;
                print(stringdisabled);
                if (GameObject.Find(stringdisabled))
                {
                    GameObject.Find(stringdisabled).GetComponent<Button>().interactable = false;
                }
                if (stringToEnabl2 != null)
                {
                    stringToEnabl2 = stringToEnabl2 + 2;
                    if (GameObject.Find(stringToEnabl2))
                    {
                        GameObject.Find(stringToEnabl2).GetComponent<Button>().interactable = true;
                    }
                }
                clicked2 = true;
            }
            else
            {
                TurnOffUpgrade2();
            }
        }
    }
    private void TurnOffUpgrade2()
    {
        LeanTween.move(upgrade2.transform.GetChild(0).gameObject, upgrade2.transform.GetChild(5).position, 0.5f);
        LeanTween.move(upgrade2.transform.GetChild(1).gameObject, upgrade2.transform.GetChild(5).position, 0.5f);
        LeanTween.move(upgrade2.transform.GetChild(2).gameObject, upgrade2.transform.GetChild(5).position, 0.5f);
        LeanTween.move(upgrade2.transform.GetChild(3).gameObject, upgrade2.transform.GetChild(5).position, 0.5f);
        LeanTween.move(upgrade2.transform.GetChild(4).gameObject, upgrade2.transform.GetChild(5).position, 0.5f);

        upgrade2.transform.GetChild(0).gameObject.SetActive(false);
        upgrade2.transform.GetChild(1).gameObject.SetActive(false);
        upgrade2.transform.GetChild(2).gameObject.SetActive(false);
        upgrade2.transform.GetChild(3).gameObject.SetActive(false);
        upgrade2.transform.GetChild(4).gameObject.SetActive(false);
        clicked2 = false;
    }
    private void TurnOffUpgrade1()
    {
        LeanTween.move(upgrade1.transform.GetChild(0).gameObject, upgrade1.transform.GetChild(5).position, 0.5f);
        LeanTween.move(upgrade1.transform.GetChild(1).gameObject, upgrade1.transform.GetChild(5).position, 0.5f);
        LeanTween.move(upgrade1.transform.GetChild(2).gameObject, upgrade1.transform.GetChild(5).position, 0.5f);
        LeanTween.move(upgrade1.transform.GetChild(3).gameObject, upgrade1.transform.GetChild(5).position, 0.5f);
        LeanTween.move(upgrade1.transform.GetChild(4).gameObject, upgrade1.transform.GetChild(5).position, 0.5f);

        upgrade1.transform.GetChild(0).gameObject.SetActive(false);
        upgrade1.transform.GetChild(1).gameObject.SetActive(false);
        upgrade1.transform.GetChild(2).gameObject.SetActive(false);
        upgrade1.transform.GetChild(3).gameObject.SetActive(false);
        upgrade1.transform.GetChild(4).gameObject.SetActive(false);
        clicked1 = false;
    }
    public void ApplyUpgrade(int upgradeNumber)
    {
        if (upgradeNumber <=4 )
        {
            shipsSelector.RemoveStatsUpgrades(upgradeSelected1);
            
            upgrade = upgradeNumber;
            LeanTween.move(upgrade1.transform.GetChild(0).gameObject, upgrade1.transform.GetChild(5).position, 0);
            
            Weapons weap = (Weapons)upgrades[upgradeNumber];
            DisableUpgrade(weap.weapName, 1);

            //upgrade1.transform.GetChild(0).gameObject.SetActive(false);
            upgradeImage1.enabled = true;
            upgradeImage1.sprite = weap.artwork;
            upgradeSelected1 = upgrades[upgradeNumber];
            SpaceShips selectedShip = shipsSelector.GetActualSpaceShip();
            print("Se ha cambiado el actualweapon");
            shipsSelector.UpdateStatsUpgrades(0,weap);
        }
        else
        {
            shipsSelector.RemoveStatsUpgrades(upgradeSelected2);
            upgradeNumber -= 5;
            upgrade = upgradeNumber;
            LeanTween.move(upgrade1.transform.GetChild(0).gameObject, upgrade1.transform.GetChild(5).position, 0);
            upgrade1.transform.GetChild(0).gameObject.SetActive(false);
            Weapons weap = (Weapons)upgrades[upgradeNumber];
            DisableUpgrade(weap.weapName, 2);
            upgradeImage2.enabled = true;
            upgradeImage2.sprite = weap.artwork;
            upgradeSelected2 = upgrades[upgradeNumber];
            SpaceShips selectedShip = shipsSelector.GetActualSpaceShip();
            print("Se ha cambiado el actualweapon");
            shipsSelector.UpdateStatsUpgrades(1, weap);
        }
    }
    private void DisableUpgrade(string upgradeName, int a)
    {
        if (stringToEnable != null)
        {
            stringToEnabl2 = stringToEnable;
            EnableUpgrade(stringToEnable, a);
        }
        stringdisabled = upgradeName;
        stringToEnable = upgradeName;
        if (a == 1)
        {
            upgradeName = upgradeName + a;
            if (GameObject.Find(upgradeName))
            {
                GameObject.Find(upgradeName).GetComponent<Button>().interactable = false;
            }
            
        }
        else
        {
            upgradeName = upgradeName + a;
            if (GameObject.Find(upgradeName))
            {
                GameObject.Find(upgradeName).GetComponent<Button>().interactable = false;
            }

        }
        
    }
    private void EnableUpgrade(string upgradeName, int a)
    {
        stringToEnable = upgradeName;
        if (a == 1)
        {
            upgradeName = upgradeName + a;
            if (GameObject.Find(upgradeName))
            {
                GameObject.Find(upgradeName).GetComponent<Button>().interactable = true;
            }

        }
        else
        {
            upgradeName = upgradeName + a;
            if (GameObject.Find(upgradeName))
            {
                GameObject.Find(upgradeName).GetComponent<Button>().interactable = true;
            }

        }
    }
    public void BossDefeated()
    {
        upgradeSelected2 = upgrades[1];
    }
}
