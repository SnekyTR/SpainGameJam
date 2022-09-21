using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipsSelector : MonoBehaviour
{

    [SerializeField] private ScriptableObject[] ships;
    private TextMeshProUGUI dmg;
    private TextMeshProUGUI hp;
    private TextMeshProUGUI speed;
    private TextMeshProUGUI attackSpeed;
    private Image shipImage;

    private int actualship = 0;
    private int oldShip = 0;

    private Button upBut;
    private Button downBut;
    private void Awake()
    {
        Assign();
        AssignSpaceShip(0);
    }
    private void Start()
    {

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
        dmg = GameObject.Find("dmg").GetComponent<TextMeshProUGUI>();
        hp = GameObject.Find("hp").GetComponent<TextMeshProUGUI>();
        speed = GameObject.Find("speed").GetComponent<TextMeshProUGUI>();
        attackSpeed = GameObject.Find("atks").GetComponent<TextMeshProUGUI>();
    }
    private void AssignSpaceShip(int i)
    {
        DeselectShip();
        SpaceShips selectedShip = (SpaceShips)ships[i];
        dmg.text = selectedShip.dmg.ToString();
        hp.text = selectedShip.hp.ToString();
        speed.text = selectedShip.speed.ToString();
        attackSpeed.text = selectedShip.attackSpeed.ToString();
        attackSpeed.text = selectedShip.attackSpeed.ToString();
        selectedShip.selected = true;
        oldShip = i;
        //shipImage.sprite = selectedShip.artwork;
    }
    private void DeselectShip()
    {
        SpaceShips old = (SpaceShips)ships[oldShip];
        old.selected = false;
    }
    public SpaceShips GetShip()
    {
        return (SpaceShips)ships[actualship];
    }
}
