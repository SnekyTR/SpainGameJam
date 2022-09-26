using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ships", menuName = "ScriptableObjects/Ship", order = 1)]
public class SpaceShips : ScriptableObject
{
    public int shipName;
    public int dmg;
    public int hp;
    public float speed;
    public float attackSpeed;
    public bool selected;
    public string weapName;
    public Sprite artwork;
    public int actualWeapon;
    public int upgrade1;
    public int upgrade2;
}
