using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShipsData
{
    public int shipName;
    public int damage;
    public float attackSpeed;
    public int health;
    public float speed;
    public bool selected;
    public int weapon;
    public int upgrade1;
    public int upgrade2;
    public ShipsData(SpaceShips ship)
    {
        shipName = ship.shipName;
        damage = ship.dmg;
        health = ship.hp;
        speed = ship.speed;
        selected = ship.selected;
        weapon = ship.actualWeapon;
        upgrade1 = ship.upgrade1;
        upgrade2 = ship.upgrade2;
    }
}
