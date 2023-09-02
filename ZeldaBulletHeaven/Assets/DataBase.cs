using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public int[] levelUpOptions;
    public float[,,] Weapon;
    //Weapons, Stats, Levels
    //damage, haste, size, speed, amount
    public string[] names;
    public int[] weights;
    public string[] weaponNames;
    public int[] weaponWeights;
    public string[] itemNames;
    public int[] itemWeights;
    public string[] statUpNames;
    public int[] statUpWeights;
    void Start()
    {
        Weapon = new float[2, 5, 7] { //Weapon Stats
                { { 10, 10, 12, 12, 12, 15, 17 }, { 100, 100, 90, 90, 85, 80, 75 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 } },
                { { 8, 8, 8, 12, 12, 15, 15}, { 120, 120, 90, 90, 85, 80, 75}, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 2, 2, 2, 3 } }
             }; //Damage, Haste, Size, Projectile Speed, Multishot

        names = new string[51]
        {
            "Sword", "Bow", "Boomerang", "Bombchu", "Hookshot", "Slingshot", "Hammer", "Spinner", "Ball & Chain", "Beetle", "Whip", "Bee Badge", //12
            "Fire Rod", "Ice Rod", "Sand Rod", "Lightning Rod", "Deku Leaf", "Ether Medallion", "Bombos Medallion", "Quake Medallion", "Ocarina of Time", //9
            "Net", "Bunny Hood", "Lon Lon Milk", "Chateau Romani", "Blue Ring", "Power Glove", "Iron Boots", "Fishing Rod", "Giant Wallet", //9
            "Magic Armor", "Lens of Truth", "Fairy", "Tornado Rod", "Pegasus Boots", "Mirror Shield", "Weapon Pouch", "Zora Flipper", "Roc's Feather", "Stamina Scroll", "Goddess Harp", //11
            "Health", "Attack", "Speed", "Critical", "Haste", "Pickup", "Luck", //7
            "Skill1", "Skill2", "Skill3", //3
        };
        weights = new int[51] //chance of each option appearing during level up
        {
            3, 3, 4, 3, 2, 4, 2, 2, 3, 4, 3, 2,
            3, 3, 2, 3, 3, 2, 2, 2, 1,
            4, 3, 1, 1, 2, 3, 3, 4, 2,
            3, 2, 2, 4, 3, 2, 1, 3, 2, 3, 1,
            1, 1, 1, 1, 1, 1, 1,
            1, 1, 1
        };
        weaponNames = new string[21] {
            "Sword", "Bow", "Boomerang", "Bombchu", "Hookshot", "Slingshot", "Hammer", "Spinner", "Ball & Chain", "Beetle", "Whip", "Bee Badge",
            "Fire Rod", "Ice Rod", "Sand Rod", "Lightning Rod", "Deku Leaf", "Ether Medallion", "Bombos Medallion", "Quake Medallion", "Ocarina of Time",
            };
        weaponWeights = new int[21]
        {
            3, 3, 4, 3, 2, 4, 2, 2, 3, 4, 3, 2,
            3, 3, 2, 3, 3, 2, 2, 2, 1
        };
        itemNames = new string[20] {
            "Net", "Bunny Hood", "Lon Lon Milk", "Chateau Romani", "Blue Ring", "Power Glove", "Iron Boots", "Fishing Rod", "Giant Wallet",
            "Magic Armor", "Lens of Truth", "Fairy", "Tornado Rod", "Pegasus Boots", "Mirror Shield", "Weapon Pouch", "Zora Flipper", "Roc's Feather", "Stamina Scroll", "Goddess Harp",
        };
        itemWeights = new int[20]
        {
            4, 3, 1, 1, 2, 3, 3, 4, 2,
            3, 2, 2, 4, 3, 2, 1, 3, 2, 3, 1
        };

        statUpNames = new string[7] {
            "Health", "Attack", "Speed", "Critical", "Haste", "Pickup", "Luck",
        };
        statUpWeights = new int[7]
        {
            1,1,1,1,1,1,1
        };
    }
}