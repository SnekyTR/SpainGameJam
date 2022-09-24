using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenu : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] weapons;
    public ScriptableObject weaponSelected;
    private GameObject upgrade1;
    private GameObject upgrade2;
    private bool clicked1;
    private bool clicked2;
    private Image upgradeImage;

    ShipsSelector shipsSelector;
    // Start is called before the first frame update
    void Start()
    {
        upgrade1 = GameObject.Find("Upgrade1");
        upgradeImage = GameObject.Find("Upgrade1Selected").GetComponent<Image>();
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
    public void UpgradeButton(int i)
    {
        if(i == 1)
        {
            if (!clicked1)
            {
                LeanTween.move(upgrade1.transform.GetChild(0).gameObject, upgrade1.transform.GetChild(2).position, 0.5f);
                upgrade1.transform.GetChild(0).gameObject.SetActive(true);
                clicked1 = true;
            }
            else
            {
                LeanTween.move(upgrade1.transform.GetChild(0).gameObject, upgrade1.transform.GetChild(1).position, 0.5f);
                
                upgrade1.transform.GetChild(0).gameObject.SetActive(false);
                clicked1 = false;
            }
            
        }
        else
        {
            if (!clicked2)
            {
                LeanTween.move(upgrade1, upgrade2.transform.GetChild(1).position, 0.5f);
                clicked2 = true;
            }else
            {

            }
        }
    }
    public void ApplyBuff(int weapNumber)
    {
        if(weapNumber == 0)
        {
            LeanTween.move(upgrade1.transform.GetChild(0).gameObject, upgrade1.transform.GetChild(1).position, 0);
            upgrade1.transform.GetChild(0).gameObject.SetActive(false);
            Weapons weap = (Weapons)weapons[weapNumber];
            upgradeImage.enabled = true;
            upgradeImage.sprite = weap.artwork;
            weaponSelected = weapons[weapNumber];

        }
        
    }
}
