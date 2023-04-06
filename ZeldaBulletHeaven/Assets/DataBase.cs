using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public string[] weaponName = { "Sword", "Bow", "Boomerang", "Hammer" };
    public int[,,] Weapon;
    //Weapons, Stats, Levels
    //damage, haste, size, speed, amount
    void Start()
    {
        Weapon = new int[1, 5, 7] { { { 1, 2, 3, 4, 5, 6, 7 }, { 100, 100, 90, 90, 85, 80, 75 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 } } };
    }


}
