using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public string[] optionNames;
    public int[,,] Weapon;
    public int[] levelUpOptions;
    public int[] types = new int[51];
    //Weapons, Stats, Levels
    //damage, haste, size, speed, amount
    void Start()
    {
        Weapon = new int[2, 5, 7] {
                { { 10, 10, 12, 12, 12, 15, 17 }, { 100, 100, 90, 90, 85, 80, 75 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 } },
                { { 8, 8, 8, 12, 12, 15, 15}, { 120, 120, 90, 90, 85, 80, 75}, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 1, 1, 1, 1 }, { 1, 1, 1, 2, 2, 2, 3 } }
             };
        optionNames = new string[51] {
            "Sword", "Boomerang", "Bombchu", "Bow", "Hookshot", "Slingshot", "Hammer", "Spinner", "Ball & Chain", "Beetle", "Whip", "Bee Badge",
            "Fire Rod", "Ice Rod", "Sand Rod", "Lightning Rod", "Deku Leaf", "Ether Medallion", "Bombos Medallion", "Quake Medallion", "Ocarina of Time",
            "Net", "Bunny Hood", "Lon Lon Milk", "Chateau Romani", "Blue Ring", "Power, Glove", "Iron Boots", "Fishing Rod", "Giant Wallet",
            "Magic Armor", "Lens of Truth", "Fairy", "Tornado Rod", "Pegasus Boots", "Mirror Shield", "Weapon Pouch", "Zora Flipper", "Roc's Feather", "Stamina Scroll", "Goddess Harp",
            "Health", "Attack", "Speed", "Critical", "Haste", "Pickup", "Luck",
            "Skill 1", "Skill 2", "Skill 3"
        };
    }
}
