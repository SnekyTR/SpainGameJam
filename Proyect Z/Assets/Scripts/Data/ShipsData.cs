using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShipsData
{
    public string shipName;
    public int damage;
    public float attackSpeed;
    public int health;
    public float speed;
    public bool selected;
    public ShipsData(SpaceShips ship)
    {
        shipName = ship.shipName;
        damage = ship.dmg;
        health = ship.hp;
        speed = ship.speed;
        selected = ship.selected;
    }
}
