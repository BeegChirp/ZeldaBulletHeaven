using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScript : MonoBehaviour
{
    public Transform playerPos;
    public PlayerScript player;
    public LogicScript logic;
    public DataBase data;
    public GameObject Sword, Arrow;
    public GameObject[] Weapon;
    public float[] weaponCooldown;
    void Start()
    {
        Weapon = new GameObject[2] { Sword, Arrow, };
        weaponCooldown = new float[6]; //cooldowns for weapon inventory
    }
    void Update()
    {
        //swordHaste = data.WeaponStats[0, 1, player.weaponInventory[0, 1]] * player.haste;
        transform.SetPositionAndRotation(logic.FollowPlayer(-1), logic.Aim(transform.position));
    }
    void FixedUpdate()
    {
        if (player.health > 0) //if player is alive
        {
            for (int slot = 0; slot < player.weaponInventory.Length / 2; slot++) //look through each weapon inventory slot
            {
                if (player.weaponInventory[slot, 0] > -1) //if there is a weapon
                {
                    Attack(player.weaponInventory[slot, 0], slot); //attack with that weapon
                }
            }
        }
    }
    private void Attack(int id, int slot)
    {
        if (weaponCooldown[slot] <= 0) //if this weapon's cooldown is up
        {
            Instantiate(Weapon[id], transform.position, logic.Aim(playerPos.position)); //spawn new attack            
            weaponCooldown[slot] = data.WeaponStats[id, 1, player.weaponInventory[slot, 1]] * player.haste; //reset cooldown
        }
        else
        {
            weaponCooldown[slot]--; //deplete cooldown
        }
    }
}
