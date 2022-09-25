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
        upgradesMenu = GameObject.Find("Upgrades").GetComponent<UpgradesMenu>();
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
        for(int i= 0; i< 5; i++)
        {
            dmg[i] = GameObject.Find("dmg").transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < 5; i++)
        {
            hp[i] = GameObject.Find("hp").transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < 5; i++)
        {
            speed[i] = GameObject.Find("speed").transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < 5; i++)
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
        int weaponNumber = upgradesMenu.GetWeapNumber();
        selectedShip.actualWeapon = weaponNumber;   
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
        for (int a = 0; a < actualWeap.dmg; a++)
        {
            dmg[a].SetActive(true);
        }
    }
}
