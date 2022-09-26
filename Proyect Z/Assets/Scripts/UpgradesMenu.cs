using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenu : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] weapons;
    public ScriptableObject weaponSelected;
    private GameObject weapon1;
    private bool clicked1;
    private Image weaponImage;

    ShipsSelector shipsSelector;
    private int weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon1 = GameObject.Find("Weapons1");
        weaponImage = GameObject.Find("Weapon1Selected").GetComponent<Image>();
        shipsSelector = GameObject.Find("SpaceShipZone").GetComponent<ShipsSelector>();
        
    }
    public void GetProgression(int progressionNumber)
    {
        if(progressionNumber == 1)
        {
            GameObject upgrade1 = gameObject.transform.GetChild(0).gameObject;
            upgrade1.SetActive(true);
        }
    }
    public void WeaponButton(int i)
    {
        if(i == 1)
        {
            if (!clicked1)
            {
                LeanTween.move(weapon1.transform.GetChild(0).gameObject, weapon1.transform.GetChild(6).position, 0.5f);
                LeanTween.move(weapon1.transform.GetChild(1).gameObject, weapon1.transform.GetChild(7).position, 0.5f);
                LeanTween.move(weapon1.transform.GetChild(2).gameObject, weapon1.transform.GetChild(8).position, 0.5f);
                LeanTween.move(weapon1.transform.GetChild(3).gameObject, weapon1.transform.GetChild(9).position, 0.5f);
                LeanTween.move(weapon1.transform.GetChild(4).gameObject, weapon1.transform.GetChild(10).position, 0.5f);
                weapon1.transform.GetChild(0).gameObject.SetActive(true);
                weapon1.transform.GetChild(1).gameObject.SetActive(true);
                weapon1.transform.GetChild(2).gameObject.SetActive(true);
                weapon1.transform.GetChild(3).gameObject.SetActive(true);
                weapon1.transform.GetChild(4).gameObject.SetActive(true);
                clicked1 = true;
            }
            else
            {
                LeanTween.move(weapon1.transform.GetChild(0).gameObject, weapon1.transform.GetChild(5).position, 0.5f);
                LeanTween.move(weapon1.transform.GetChild(1).gameObject, weapon1.transform.GetChild(5).position, 0.5f);
                LeanTween.move(weapon1.transform.GetChild(2).gameObject, weapon1.transform.GetChild(5).position, 0.5f);
                LeanTween.move(weapon1.transform.GetChild(3).gameObject, weapon1.transform.GetChild(5).position, 0.5f);
                LeanTween.move(weapon1.transform.GetChild(4).gameObject, weapon1.transform.GetChild(5).position, 0.5f);
                
                weapon1.transform.GetChild(0).gameObject.SetActive(false);
                weapon1.transform.GetChild(1).gameObject.SetActive(false);
                weapon1.transform.GetChild(2).gameObject.SetActive(false);
                weapon1.transform.GetChild(3).gameObject.SetActive(false);
                weapon1.transform.GetChild(4).gameObject.SetActive(false);
                clicked1 = false;
            }
            
        }
    }
    public void ApplyWeapon(int weapNumber)
    {
        shipsSelector.RemoveStatsWeap(weaponSelected);
            weapon = weapNumber;
            LeanTween.move(weapon1.transform.GetChild(0).gameObject, weapon1.transform.GetChild(5).position, 0);
            weapon1.transform.GetChild(0).gameObject.SetActive(false);
            Weapons weap = (Weapons)weapons[weapNumber];

            weaponImage.enabled = true;
            weaponImage.sprite = weap.artwork;
            weaponSelected = weapons[weapNumber];
            SpaceShips selectedShip= shipsSelector.GetActualSpaceShip();
            print("Se ha cambiado el actualweapon" + weapNumber);
        shipsSelector.UpdateStatsWeapon(weap);
    }
    public int GetWeapNumber()
    {
        return weapon;
    }
}
