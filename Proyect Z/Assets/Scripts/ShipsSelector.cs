using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipsSelector : MonoBehaviour
{

    [SerializeField] private ScriptableObject[] ships;
    [HideInInspector]public TextMeshProUGUI shipName;
    [SerializeField] private GameObject[] dmg;
    [SerializeField] private GameObject[] hp;
    [SerializeField] private GameObject[] speed;
    [SerializeField] private GameObject[] attackSpeed;
    private SpaceShips selectedShip;
    private Image shipImage;

    private int upgr1;
    private int upgr2 = 15;
    private int weapNumber;
    private ScriptableObject weap1;

    private int actualship = 0;
    private int oldShip = 0;

    private Button upBut;
    private Button downBut;

    [SerializeField] private UpgradesMenu upgradesMenu;
    private void Awake()
    {
        Assign();
    }
    private void Start()
    {
        upgradesMenu = GameObject.Find("Weapons").GetComponent<UpgradesMenu>();
        AssignSpaceShip(0);
        
    }
    public void ChangeShip(int i)
    {

        actualship += (i);

        if(actualship >= 0)
        {
            if(actualship < ships.Length)
            {
                print(actualship);
                AssignSpaceShip(actualship);
            }
            else
            {
                actualship -= (i);
            }
        }
        else
        {
            actualship -=(i);
        }
        
    }
    private void Assign()
    {
        //dmg[0] = GameObject.Find("dmg").transform.GetChild(1).gameObject;
        for(int i= 0; i< 7; i++)
        {
            dmg[i] = GameObject.Find("dmg").transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < 7; i++)
        {
            hp[i] = GameObject.Find("hp").transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < 7; i++)
        {
            speed[i] = GameObject.Find("speed").transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < 7; i++)
        {
            attackSpeed[i] = GameObject.Find("atks").transform.GetChild(i).gameObject;
        }
        shipImage = GameObject.Find("ShipImage").GetComponent<Image>();
        shipName = GameObject.Find("ShipName").GetComponent<TextMeshProUGUI>();
    }
    private void AssignSpaceShip(int i)
    {
        
        DeselectShip();
        selectedShip = (SpaceShips)ships[i];
        Weapons selectedWeapon = (Weapons)upgradesMenu.weaponSelected;
        selectedShip.actualWeapon = weapNumber;
        if(upgr2 == 15)
        {
            selectedShip.upgrade2 = upgr2;
        }
        print("UPGRADE ASIGNADA AL CAMBIAR");
        selectedShip.upgrade1 = upgr1;
        
        shipImage.sprite = selectedShip.artwork;
        for(int a = 0; a < selectedWeapon.dmg; a++)
        {
            dmg[a].SetActive(true);
        }
        for (int a = 0; a < selectedShip.hp; a++)
        {
            hp[a].SetActive(true);
        }
        for (int a = 0; a < selectedShip.speed; a++)
        {
            speed[a].SetActive(true);
        }
        for (int a = 0; a < selectedWeapon.attackSpeed; a++)
        {
            attackSpeed[a].SetActive(true);
        }
        //dmg.text = selectedShip.dmg.ToString();
        //hp.text = selectedShip.hp.ToString();
        //speed.text = selectedShip.speed.ToString();
        //attackSpeed.text = selectedShip.attackSpeed.ToString();
        //attackSpeed.text = selectedShip.attackSpeed.ToString();
        selectedShip.selected = true;
        oldShip = i;
        //shipImage.sprite = selectedShip.artwork;
    }
    public SpaceShips GetActualSpaceShip()
    {
        return selectedShip;
    }
    private void DeselectShip()
    {
        SpaceShips old = (SpaceShips)ships[oldShip];
        for (int a = 0; a < dmg.Length; a++)
        {
            dmg[a].SetActive(false);
        }
        for (int a = 0; a < hp.Length; a++)
        {
            hp[a].SetActive(false);
        }
        for (int a = 0; a < speed.Length; a++)
        {
            speed[a].SetActive(false);
        }
        for (int a = 0; a < attackSpeed.Length; a++)
        {
            attackSpeed[a].SetActive(false);
        }
        old.selected = false;
    }
    public SpaceShips GetShip()
    {
        return (SpaceShips)ships[actualship];
    }
    public void UpdateStatsWeapon(ScriptableObject weapon)
    {
        Weapons actualWeap = (Weapons)weapon;
        weap1 = weapon;
        print("La arma es esta: " + actualWeap);
        switch (actualWeap.weapName)
        {
            case "Weapon01":
                weapNumber = 0;
                selectedShip.actualWeapon = 0;
                for (int a = 0; a < actualWeap.dmg; a++)
                {
                    dmg[a].SetActive(true);
                }
                for (int a = 0; a < actualWeap.attackSpeed; a++)
                {
                    attackSpeed[a].SetActive(true);
                }
                break;
            case "Weapon02":
                weapNumber = 1;
                selectedShip.actualWeapon = 1;
                for (int a = 0; a < actualWeap.dmg; a++)
                {
                    dmg[a].SetActive(true);
                }
                for (int a = 0; a < actualWeap.attackSpeed; a++)
                {
                    attackSpeed[a].SetActive(true);
                }
                break;
            case "Weapon03":
                weapNumber = 2;
                selectedShip.actualWeapon = 2;
                for (int a = 0; a < actualWeap.dmg; a++)
                {
                    dmg[a].SetActive(true);
                }
                for (int a = 0; a < actualWeap.attackSpeed; a++)
                {
                    attackSpeed[a].SetActive(true);
                }
                break;
            case "Weapon04":
                weapNumber = 3;
                selectedShip.actualWeapon = 3;
                for (int a = 0; a < actualWeap.dmg; a++)
                {
                    dmg[a].SetActive(true);
                }
                for (int a = 0; a < actualWeap.attackSpeed; a++)
                {
                    attackSpeed[a].SetActive(true);
                }
                break;
            case "Weapon05":
                weapNumber = 4;
                selectedShip.actualWeapon = 4;
                for (int a = 0; a < actualWeap.dmg; a++)
                {
                    dmg[a].SetActive(true);
                }
                for (int a = 0; a < actualWeap.attackSpeed; a++)
                {
                    attackSpeed[a].SetActive(true);
                }
                break;
        }
    }
    public void RemoveStatsWeap(ScriptableObject weapon)
    {
        Weapons actualWeap = (Weapons)weapon;
        weap1 = weapon;
        print("La arma es esta: " + actualWeap);
        switch (actualWeap.weapName)
        {
            case "Weapon01":
                for (int a = 0; a < actualWeap.dmg; a++)
                {
                    dmg[a].SetActive(false);
                }
                for (int a = 0; a < actualWeap.attackSpeed; a++)
                {
                    attackSpeed[a].SetActive(false);
                }
                break;
            case "Weapon02":
                for (int a = 0; a < actualWeap.dmg; a++)
                {
                    dmg[a].SetActive(false);
                }
                for (int a = 0; a < actualWeap.attackSpeed; a++)
                {
                    attackSpeed[a].SetActive(false);
                }
                break;
            case "Weapon03":
                for (int a = 0; a < actualWeap.dmg; a++)
                {
                    dmg[a].SetActive(false);
                }
                for (int a = 0; a < actualWeap.attackSpeed; a++)
                {
                    attackSpeed[a].SetActive(false);
                }
                break;
            case "Weapon04":
                for (int a = 0; a < actualWeap.dmg; a++)
                {
                    dmg[a].SetActive(false);
                }
                for (int a = 0; a < actualWeap.attackSpeed; a++)
                {
                    attackSpeed[a].SetActive(false);
                }
                break;
            case "Weapon05":
                for (int a = 0; a < actualWeap.dmg; a++)
                {
                    dmg[a].SetActive(false);
                }
                for (int a = 0; a < actualWeap.attackSpeed; a++)
                {
                    attackSpeed[a].SetActive(false);
                }
                break;
        }
    }
    public void UpdateStatsUpgrades(int casilla, ScriptableObject upgrade)
    {
        if(casilla == 0)
        {
            Weapons actualUpgrade = (Weapons)upgrade;
            switch (actualUpgrade.weapName)
            {
                case "Upgrade01":
                    upgr1 = 0;
                    selectedShip.upgrade1 = 0;
                    for (int i = 0; i < hp.Length; i++)
                    {
                        if (!hp[i].activeInHierarchy)
                        {
                            hp[i].SetActive(true);
                            break;
                        }
                    }
                    break;
                case "Upgrade02":
                    upgr1 = 1;
                    selectedShip.upgrade1 = 1;
                    for (int i = 0; i < dmg.Length; i++)
                    {
                        if (!dmg[i].activeInHierarchy)
                        {
                            dmg[i].SetActive(true);
                            break;
                        }
                    }
                    break;
                case "Upgrade03":
                    upgr1 = 2;
                    selectedShip.upgrade1 = 2;
                    for (int i = 0; i < speed.Length; i++)
                    {
                        if (!speed[i].activeInHierarchy)
                        {
                            speed[i].SetActive(true);
                            break;
                        }
                    }
                    break;
                case "Upgrade04":
                    upgr1 = 3;
                    selectedShip.upgrade1 = 3;
                    break;
                case "Upgrade05":
                    upgr1 = 4;
                    selectedShip.upgrade1 = 4;
                    break;
            }
        }
        else
        {

            Weapons actualUpgrade = (Weapons)upgrade;
            switch (actualUpgrade.weapName)
            {
                case "Upgrade01":
                    selectedShip.upgrade2 = 0;
                    for (int i = 0; i < hp.Length; i++)
                    {
                        if (!hp[i].activeInHierarchy)
                        {
                            hp[i].SetActive(true);
                            break;
                        }
                    }
                    break;
                case "Upgrade02":
                    selectedShip.upgrade2 = 1;
                    for (int i = 0; i < dmg.Length; i++)
                    {
                        if (!dmg[i].activeInHierarchy)
                        {
                            dmg[i].SetActive(true);
                            break;
                        }
                    }
                    break;
                case "Upgrade03":
                    selectedShip.upgrade2 = 2;
                    for (int i = 0; i < speed.Length; i++)
                    {
                        if (!speed[i].activeInHierarchy)
                        {
                            speed[i].SetActive(true);
                            break;
                        }
                    }
                    break;
                case "Upgrade04":
                    selectedShip.upgrade2 = 3;
                    break;
                case "Upgrade05":
                    selectedShip.upgrade2 = 4;
                    break;
            }
        }
    }
    public void RemoveStatsUpgrades(ScriptableObject upgrade)
    {
        Weapons actualUpgrade = (Weapons)upgrade;
        switch (actualUpgrade.weapName)
        {
            case "Upgrade01":
                for (int i = 0; i < hp.Length; i++)
                {
                    if (!hp[i].activeInHierarchy)
                    {
                        i--;
                        hp[i].SetActive(false);
                        break;
                    }
                }
                break;
            case "Upgrade02":
                for (int i = 0; i < dmg.Length; i++)
                {
                    if (!dmg[i].activeInHierarchy)
                    {
                        i--;
                        dmg[i].SetActive(false);
                        break;
                    }
                }
                break;
            case "Upgrade03":
                for (int i = 0; i < attackSpeed.Length; i++)
                {
                    if (!attackSpeed[i].activeInHierarchy)
                    {
                        i--;
                        attackSpeed[i].SetActive(false);
                        break;
                    }
                }
                break;
            case "Upgrade04":
                for (int i = 0; i < speed.Length; i++)
                {
                    if (!speed[i].activeInHierarchy)
                    {
                        i--;
                        speed[i].SetActive(false);
                        break;
                    }
                }
                break;
        }
    }
}
