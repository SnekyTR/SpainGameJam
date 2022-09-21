using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ships", menuName = "ScriptableObjects/Ship", order = 1)]
public class SpaceShips : ScriptableObject
{
    public string shipName;
    public int dmg;
    public int hp;
    public float speed;
    public float attackSpeed;
    public bool selected;
    public string weapName;
    public Sprite artwork;
}
