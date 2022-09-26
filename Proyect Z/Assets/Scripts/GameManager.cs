using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int shipName;
    public int weaponName;
    public int upgrade01, upgrade02;        //valores que se deben cargar datos

    private int energy = 0;
    private float progress = 0f;

    public TextMeshProUGUI energyTxt;
    public TextMeshProUGUI progressTxt;
    public Image energyImg, progressImg;

    public Color color01, color02, color03, color04;

    public List<GameObject> lifesImg;
    public List<Sprite> puImgs;
    public Image puR, saR;

    public GameObject winPanel, losePanel;

    public List<PlayerShip> ships;
    public List<WeaponPU> weapons;

    [HideInInspector] public GameObject player;

    [HideInInspector] public float extraDmg = 1; 
    [HideInInspector] public float extraVel = 1; 
    [HideInInspector] public float extraTime = 1;

    public bool isEnd;
    public GameObject boss;
    public Transform bossPos;

    public GameObject ai04Generator, aiGenerator;

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

        energyImg.fillAmount = ((int)energy / 100f);

        if (energy == 100)
        {
            energyImg.color = color01;
        }
        else if (energy >= 50)
        {
            energyImg.color = color02;
        }
        else
        {
            energyImg.color = color03;
        }
    }

    void Update()
    {

    }
    public void LoadShips()
    {
        /*ShipsData data = SaveSystem.LoadShips();

        shipName = data.shipName;
        weaponName = data.weapon;
        upgrade01 = data.upgrade1;
        upgrade02 = data.upgrade2;*/
    }
    private void FixedUpdate()
    {
        if (energy == 100 && progress < 100)
        {
            progress += Time.fixedDeltaTime * 1.2f;

            progressTxt.text = ((int)progress).ToString() + "%";

            progressImg.fillAmount = ((int)progress / 100f);
        }
        else if (!isEnd && progress >= 100)
        {
            isEnd = true;

            Destroy(ai04Generator);
            Destroy(aiGenerator);

            Instantiate(boss, bossPos.position, transform.rotation);
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

        if(energy <= 100)
        {
            energyImg.fillAmount = ((int)energy / 100f);

            if(energy == 100)
            {
                energyImg.color = color01;
            }
            else if(energy >= 50)
            {
                energyImg.color = color02;
            }
            else
            {
                energyImg.color = color03;
            }
        }
        else
        {
            energyImg.fillAmount = 1;

            energyImg.color = color04;
        }
    }

    public float GetProgress()
    {
        return progress;
    }

    public void MoreLifes()
    {
        player.GetComponent<PlayerShip>().SetLife(1);
    }

    public void FinishGame()
    {
        Time.timeScale = 0;

        winPanel.SetActive(true);
    }

    public void Defeat()
    {
        Time.timeScale = 0;

        losePanel.SetActive(true);
    }

    public void SetPU(int i)
    {
        if(i == 1)
        {
            puR.sprite = puImgs[0];
        }
        else if(i == 2)
        {
            puR.sprite = puImgs[1];
        }
        else if (i == 3)
        {
            saR.sprite = puImgs[2];
        }
        else if (i == 4)
        {
            saR.sprite = puImgs[3];
        }
        else if (i == 5)
        {
            saR.sprite = puImgs[4];
        }
    }

    public void NoPU(int i)
    {
        if (i == 1)
        {
            puR.sprite = puImgs[5];
        }
        else if (i == 2)
        {
            saR.sprite = puImgs[6];
        }
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
