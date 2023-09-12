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
    public ArrowScript arrowScript;
    public float swordHaste;
    public float swordCooldown = 100;
    public GameObject Sword, Arrow;
    public float bowHaste = 100;
    public float bowCooldown;
    //public GameObject[] Weapons;
    public float[] weaponCooldown;
    //private List<Action> weaponAttacks;
    private Action[] weaponAttacks;
    void Start()
    {
        weaponAttacks = new Action[2] { SwordAttack, BowAttack };
    }
    void Update()
    {
        swordHaste = data.WeaponStats[0, 1, player.weaponInventory[0, 1]] * player.haste;
        transform.SetPositionAndRotation(logic.FollowPlayer(-1), logic.Aim(transform.position));
        if (swordHaste < 3)
        {
            swordHaste = 3;
        }
    }
    void FixedUpdate()
    {
        if (player.health > 0)
        {
            for (int slot = 0; slot < player.weaponInventory.Length / 2; slot++)
            {
                if (player.weaponInventory[slot, 0] > -1)
                {
                    weaponAttacks[player.weaponInventory[slot, 0]]();
                }
            }
        }
    }
    private void SwordAttack()
    {
        if (swordCooldown <= 0)
        {
            Instantiate(Sword, transform.position, logic.Aim(playerPos.position));
            swordCooldown = swordHaste;
        }
        else
        {
            swordCooldown--;
        }
    }
    private void BowAttack()
    {
        if (bowCooldown <= 0)
        {
            Instantiate(Arrow, transform.position, logic.Aim(playerPos.position));
            bowCooldown = bowHaste;
        }
        else
        {
            bowCooldown--;
        }
    }
}
