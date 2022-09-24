using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapons : ScriptableObject
{
    public string weapName;
    public int dmg;
    public float attackSpeed;
    public bool selected;
    public Sprite artwork;
}
