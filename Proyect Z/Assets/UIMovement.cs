using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMovement : MonoBehaviour
{
    private GameObject buttons;
    private Transform spaceShipZone;

    GameSave gameSave;
    ShipsSelector shipsSelector;

    private Vector2 buttonsPosition;
    private Vector2 buttonsPosition1;
    private Vector2 buttonsPosition2;
    private Vector2 spaceShipPosition;
    private Vector2 newSpaceShipPosition1;
    private Vector2 newSpaceShipPosition2;
    void Start()
    {
        buttons = GameObject.Find("Buttons");
        spaceShipZone = GameObject.Find("SpaceShipZone").transform.GetChild(0);
        buttonsPosition = buttons.transform.position;
        spaceShipPosition = spaceShipZone.transform.position;
        buttonsPosition1 = GameObject.Find("Positions").transform.GetChild(0).position;
        buttonsPosition2 = GameObject.Find("Positions").transform.GetChild(1).position;
        newSpaceShipPosition1 = GameObject.Find("Positions").transform.GetChild(2).position;
        newSpaceShipPosition2 = GameObject.Find("Positions").transform.GetChild(3).position;
        shipsSelector = GameObject.Find("SpaceShipZone").GetComponent<ShipsSelector>();
    }
    public void ActivateSpaceSelector()
    {           
        LeanTween.move(buttons, buttonsPosition2, 0.5f);
        LeanTween.move(spaceShipZone.gameObject, newSpaceShipPosition2, 0.5f);
    }
    public void DeactivateSpaceSelector()
    {
        LeanTween.move(buttons, buttonsPosition1, 0.5f);
        LeanTween.move(spaceShipZone.gameObject, newSpaceShipPosition1, 0.5f);
        SpaceShips ship = shipsSelector.GetShip();
        SaveSystem.SaveShips(ship);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
