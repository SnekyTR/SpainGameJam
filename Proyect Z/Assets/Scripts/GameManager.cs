using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public string shipName;
    public string weaponName;

    private int energy = 0;
    private float progress = 0f;

    public Text energyTxt;
    public Text progressTxt;

    public List<PlayerShip> ships;
    public List<WeaponPU> weapons;

    private GameObject player;

    private void Awake()
    {
        //cargar datos de shipName y weaponName

        if(shipName == "Ship01")
        {
            player = Instantiate(ships[0].gameObject, transform.position, Quaternion.identity);
        }
        else if (shipName == "Ship02")
        {
            player = Instantiate(ships[1].gameObject, transform.position, Quaternion.identity);
        }
        else if (shipName == "Ship03")
        {
            player = Instantiate(ships[2].gameObject, transform.position, Quaternion.identity);
        }

        if(weaponName == "Weapon01")
        {
            Instantiate(weapons[0].gameObject, transform.position, Quaternion.identity, player.transform);
        }
        else if (weaponName == "Weapon02")
        {
            Instantiate(weapons[1].gameObject, transform.position, Quaternion.identity, player.transform);
        }
        else if (weaponName == "Weapon03")
        {
            Instantiate(weapons[2].gameObject, transform.position, Quaternion.identity, player.transform);
        }
        else if (weaponName == "Weapon04")
        {
            Instantiate(weapons[3].gameObject, transform.position, Quaternion.identity, player.transform);
        }
        else if (weaponName == "Weapon05")
        {
            Instantiate(weapons[4].gameObject, transform.position, Quaternion.identity, player.transform);
        }
    }

    void Start()
    {
        energy = 100;
        energyTxt.text = energy.ToString();


    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (energy == 100 && progress < 100)
        {
            progress += Time.fixedDeltaTime * 24f;

            progressTxt.text = ((int)progress).ToString();
        }
        /*else if (energy <= 120 && energy >= 80)
        {
            progress += Time.fixedDeltaTime * 0.3f;

            progressTxt.text = ((int)progress).ToString();
        }
        else if (energy <= 200 && energy >= 0)
        {
            progress += Time.fixedDeltaTime * 0.1f;

            progressTxt.text = ((int)progress).ToString();
        }*/
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void SetEnergy(int e)
    {
        if(e > 200)
        {
            e = 200;
        }
        else if(e < 0)
        {
            e = 0;
        }

        energy = e;

        energyTxt.text = energy.ToString();
    }

    public float GetProgress()
    {
        return progress;
    }
}
