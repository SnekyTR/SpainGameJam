using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameSave
{
    private ShipsSelector shipsSelector;
    private SpaceShips[] spaceShips;
    void Awake()
    {
        shipsSelector = GameObject.Find("SpaceShipZone").GetComponent<ShipsSelector>();
    }
    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveGame(SpaceShips ship)
    {
        
    }
    public void LoadGame()
    {
        
    }
}
