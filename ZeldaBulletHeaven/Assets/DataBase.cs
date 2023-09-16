using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public int[] levelUpOptions;
    public string[] names;
    public int[] weights;
    public readonly string[] weaponNames = new string[2]  //21
        {
            "Sword", "Bow"/*, "Boomerang", "Bombchu", "Hookshot", "Slingshot", "Hammer", "Spinner", "Ball & Chain", "Beetle", "Whip", "Bee Badge",
            "Fire Rod", "Ice Rod", "Sand Rod", "Lightning Rod", "Deku Leaf", "Ether Medallion", "Bombos Medallion", "Quake Medallion", "Ocarina of Time",*/
        };
    public readonly int[] weaponWeights = new int[2] //21
        {
            3, 3/*, 4, 3, 2, 4, 2, 2, 3, 4, 3, 2,
            3, 3, 2, 3, 3, 2, 2, 2, 1*/
        };
    public readonly string[] itemNames = new string[1] { //20
            "Net"/*, "Bunny Hood", "Lon Lon Milk", "Chateau Romani", "Blue Ring", "Power Glove", "Iron Boots", "Fishing Rod", "Giant Wallet",
            "Magic Armor", "Lens of Truth", "Fairy", "Tornado Rod", "Pegasus Boots", "Mirror Shield", "Weapon Pouch", "Zora Flipper", "Roc's Feather", "Stamina Scroll", "Goddess Harp",*/
        };
    public readonly int[] itemWeights = new int[1] //20
        {
            4/*, 3, 1, 1, 2, 3, 3, 4, 2,
            3, 2, 2, 4, 3, 2, 1, 3, 2, 3, 1*/
        };
    public readonly string[] statUpNames = new string[7] {
            "Health", "Attack", "Speed", "Critical", "Haste", "Pickup", "Luck",
        };
    public readonly int[] statUpWeights = new int[7]
        {
            1,1,1,1,1,1,1
        };
    public readonly float[,,] WeaponStats = new float[3, 5, 7] //Weapon Stats
    {
        { { 10, 12, 12, 12, 12, 15, 15 }, { 100, 100, 100, 85, 85, 85, 85 }, { 1, 1, 1.25f, 1.25f, 1.25f, 1.25f, 1.25f }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 2, 2, 4 } }, //Sword
        { { 8, 8, 8, 12, 12, 15, 15 }, { 120, 120, 90, 90, 85, 80, 75 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 2, 2, 2, 3 } }, //Bow
        { { 8, 8, 8, 12, 12, 15, 15 }, { 120, 120, 90, 90, 85, 80, 75 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 2, 2, 2, 3 } } //Boomerang
    }; //Damage, Haste, Size, Projectile Speed, Multishot
    //Weapons, Stats, Levels
    public readonly float[] miscDamageTypes = new float[1]
    {
        9
    };
    public readonly int[,] xpArray = new int[4, 2]
    {
        { 1, 9 }, { 10, 4 }, { 50, 3}, {200, -1 }
    };//xpValue, xpRequiredForLvlUp
    public readonly string[] xpLevels = new string[4]
    {
        "XP1", "XP10", "XP50", "XP200"
    };
    void Start()
    {
        names = new string[51]
        {
            "Sword", "Bow", "Boomerang", "Bombchu", "Hookshot", "Slingshot", "Hammer", "Spinner", "Ball & Chain", "Beetle", "Whip", "Bee Badge", //12
            "Fire Rod", "Ice Rod", "Sand Rod", "Lightning Rod", "Deku Leaf", "Ether Medallion", "Bombos Medallion", "Quake Medallion", "Ocarina of Time", //9
            "Net", "Bunny Hood", "Lon Lon Milk", "Chateau Romani", "Blue Ring", "Power Glove", "Iron Boots", "Fishing Rod", "Giant Wallet", //9
            "Magic Armor", "Lens of Truth", "Fairy", "Tornado Rod", "Pegasus Boots", "Mirror Shield", "Weapon Pouch", "Zora Flipper", "Roc's Feather", "Stamina Scroll", "Goddess Harp", //11
            "Health", "Attack", "Speed", "Critical", "Haste", "Pickup", "Luck", //7
            "Skill1", "Skill2", "Skill3", //3
        };
        /*weights = new int[51] //chance of each option appearing during level up
        {
            3, 3, 4, 3, 2, 4, 2, 2, 3, 4, 3, 2,
            3, 3, 2, 3, 3, 2, 2, 2, 1,
            4, 3, 1, 1, 2, 3, 3, 4, 2,
            3, 2, 2, 4, 3, 2, 1, 3, 2, 3, 1,
            1, 1, 1, 1, 1, 1, 1,
            1, 1, 1
        };*/
    }
}