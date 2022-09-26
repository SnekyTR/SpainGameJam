using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int shipName;
    public int weaponName;
    public int upgrade01, upgrade02;        //valores que se deben cargar datos

    private int energy = 0;
    private float progress = 0f;

    public Text energyTxt;
    public Text progressTxt;

    public List<PlayerShip> ships;
    public List<WeaponPU> weapons;

    private int partLifes = 0;

    [HideInInspector] public GameObject player;

    [HideInInspector] public float extraDmg = 1; 
    [HideInInspector] public float extraVel = 1; 
    [HideInInspector] public float extraTime = 1;

    public bool isEnd;
    public GameObject boss;
    public Transform bossPos;

    private void Awake()
    {
        //cargar datos de shipName y weaponName
        LoadShips();
        if(shipName == 0)
        {
            player = Instantiate(ships[0].gameObject, transform.position, Quaternion.identity);
        }
        else if (shipName == 1)
        {
            player = Instantiate(ships[1].gameObject, transform.position, Quaternion.identity);
        }
        else if (shipName == 2)
        {
            player = Instantiate(ships[2].gameObject, transform.position, Quaternion.identity);
        }

        if(weaponName == 0)
        {
            Instantiate(weapons[0].gameObject, transform.position, Quaternion.identity, player.transform);
        }
        else if (weaponName == 1)
        {
            Instantiate(weapons[1].gameObject, transform.position, Quaternion.identity, player.transform);
        }
        else if (weaponName == 2)
        {
            Instantiate(weapons[2].gameObject, transform.position, Quaternion.identity, player.transform);
        }
        else if (weaponName == 3)
        {
            Instantiate(weapons[3].gameObject, transform.position, Quaternion.identity, player.transform);
        }
        else if (weaponName == 4)
        {
            Instantiate(weapons[4].gameObject, transform.position, Quaternion.identity, player.transform);
        }

        if (upgrade01 == 0 || upgrade02 == 0)
        {
            player.GetComponent<PlayerShip>().SetNewMaxLife(1);
        }
        if (upgrade01 == 1 || upgrade02 == 1)
        {
            extraDmg = 1.5f;
        }
        if (upgrade01 == 2 || upgrade02 == 2)
        {
            extraVel = 1.25f;
        }
        if (upgrade01 == 3 || upgrade02 == 3)
        {
            energy = 50;
        }
        if (upgrade01 == 4 || upgrade02 == 4)
        {
            extraTime = 1.25f;
        }
    }

    void Start()
    {
        energyTxt.text = energy.ToString();
    }

    void Update()
    {

    }
    public void LoadShips()
    {
        ShipsData data = SaveSystem.LoadShips();

        shipName = data.shipName;
        weaponName = data.weapon;
        upgrade01 = data.upgrade1;
        upgrade02 = data.upgrade2;
    }
    private void FixedUpdate()
    {
        if (energy == 100 && progress < 100)
        {
            progress += Time.fixedDeltaTime * 24f;

            progressTxt.text = ((int)progress).ToString();
        }
        else if (!isEnd)
        {
            isEnd = true;

            Instantiate(boss, bossPos.position, Quaternion.identity);
        }

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

    public void MoreLifes()
    {
        partLifes += 1;

        if(partLifes == 4)
        {
            partLifes = 0;

            player.GetComponent<PlayerShip>().SetLife(1);
        }
    }


}
