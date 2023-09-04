using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpScript : MonoBehaviour
{
    public GameObject levelUpScreen;
    public CanvasGroup levelUpCanvasGroup;
    public DataBase data;
    public PlayerScript player;
    public TextMeshProUGUI button1Text;
    public TextMeshProUGUI button2Text;
    public TextMeshProUGUI button3Text;
    public TextMeshProUGUI button4Text;
    int[] buttons = new int[4];
    string[] buttonsDisplay = new string[4];
    public List<int> weaponWeightList = new List<int>();
    public List<int> itemWeightList = new List<int>();
    private void Awake()
    {
        for (int a = 0; a < data.weaponNames.Length; a++)
        {
            for (int b = 0; b < data.weaponWeights[a]; b++)
            {
                weaponWeightList.Add(a); //make a weighted list of all weapons
            }
        }
        for (int a = 0; a < data.itemNames.Length; a++)
        {
            for (int b = 0; b < data.itemWeights[a]; b++)
            {
                itemWeightList.Add(a); //make a weighted list of all items
            }
        }
        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x] = -1; //set all buttons to empty
        }
    }
    private void Update()
    {
        //Time.timeScale = 0f;
    }
    public void LevelUp()
    {
        Time.timeScale = 0f; //pause
        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x] = -1;
        }
        for (int i = 0; i < buttons.Length; i++) //for every button on level up...
        {
            while (buttons[i] == -1) //while current option is empty...
            {
                int randomCategory = Random.Range(0, 4); //decide option category
                int randomOption;
                int weightedRoll;

                if (randomCategory == 0) //if category is weapons...
                {
                    weightedRoll = Random.Range(0, weaponWeightList.Count); //weighted roll of all weapons
                    randomOption = weaponWeightList[weightedRoll]; //save that weapon
                    buttonsDisplay[i] = data.weaponNames[randomOption]; //display that weapon name
                    ButtonText(i);
                }
                else if (randomCategory == 1) //if catgory is items...
                {
                    weightedRoll = Random.Range(0, itemWeightList.Count); //weighted roll of all items
                    randomOption = itemWeightList[weightedRoll]; //save that item ID
                    buttonsDisplay[i] = data.itemNames[randomOption]; //display that item name
                    ButtonText(i);
                    randomOption = randomOption + data.weaponNames.Length; //save item ID in global context

                }
                else if (randomCategory == 2) //if category is statUp
                {
                    randomOption = Random.Range(0, data.statUpNames.Length); //pick a stat
                    buttonsDisplay[i] = data.statUpNames[randomOption]; //display that stat name
                    ButtonText(i);
                    randomOption = randomOption + data.weaponNames.Length + data.itemNames.Length; //save stat in global context
                }
                else
                {
                    randomOption = Random.Range(0, player.skillNames.Length); //pick a skill
                    buttonsDisplay[i] = player.skillNames[randomOption]; //display that skill name
                    ButtonText(i);
                    randomOption = randomOption + data.weaponNames.Length + data.itemNames.Length + data.statUpNames.Length; //save skill in global context
                }

                //NEED TO FIND A WAY TO DETERMINE THE DIFFERENCE BETWEEN WEAPON X, ITEM X, SKILL X, AND STAT UP X
                if (i == 0 || randomOption != buttons[0] && randomOption != buttons[1] && randomOption != buttons[2]) //if option is different from all other options, or the first option
                {
                    Debug.Log(randomOption);
                    buttons[i] = randomOption; //set option to button
                    /*if (player.acquiredStuff[randomCategory] < 6) //if option is not maxLevel
                    {
                        if (player.acquiredStuff[randomCategory] < 0 && rerolled == false)
                        {

                        }
                    }*/
                }
                else //otherwise, stay in while loop
                {
                    buttons[i] = -1;
                }
            }
        }
        levelUpCanvasGroup.alpha = 1;
        
    }
    public void ButtonText(int i)
    {
        if (i == 0)
        {
            button1Text.text = buttonsDisplay[i];
        }
        else if (i == 1)
        {
            button2Text.text = buttonsDisplay[i];
        }
        else if (i == 2)
        {
            button3Text.text = buttonsDisplay[i];
        }
        else
        {
            button4Text.text = buttonsDisplay[i];
        }
    }
    public void OptionChosen(int i)
    {
        bool upgradeDone = false;
        if (buttons[i] < data.weaponNames.Length) //if option is a weapon
        {
            for (int a = 0; a < (player.weaponInventory.Length); a++)
            {
                if (a < (player.weaponInventory.Length / 2))
                {
                    if (buttons[i] == player.weaponInventory[a, 0]) //if player has this weapon
                    {
                        player.weaponInventory[a, 1]++; //increment level
                        upgradeDone = true; //player had weapon, level incremented
                    }
                }
                else if (upgradeDone == false) //if player doesn't have this weapon
                {
                    if (player.weaponInventory[(a - (player.weaponInventory.Length / 2)), 0] == -1) //find first empty slot
                    {
                        player.weaponInventory[(a - (player.weaponInventory.Length / 2)), 0] = buttons[i]; //put weapon in that slot
                        player.weaponInventory[(a - (player.weaponInventory.Length / 2)), 1]++; //increment level
                        upgradeDone = true; //weapon added to player inventory
                    }
                }
            }
        }
        else if (buttons[i] < data.itemNames.Length + data.weaponNames.Length) //if option is an item
        {
            for (int b = 0; b < (player.itemInventory.Length); b++)
            {
                if (b < (player.itemInventory.Length / 2))
                {
                    if (buttons[i] == player.itemInventory[b, 0]) //if player has this item
                    {
                        player.itemInventory[b, 1]++; //increment level
                        upgradeDone = true; //player had item, level incremented
                    }
                }
                else if (upgradeDone == false) //if player doesn't have this item
                {
                    if (player.itemInventory[(b - (player.itemInventory.Length / 2)), 0] == -1) //find first empty slot
                    {
                        player.itemInventory[(b - (player.itemInventory.Length / 2)), 0] = buttons[i]; //put item in that slot
                        player.itemInventory[(b - (player.itemInventory.Length / 2)), 1]++; //increment level
                        upgradeDone = true; //item added to player inventory
                    }
                }
            }
        }
        else if (buttons[i] < data.statUpNames.Length + data.itemNames.Length + data.weaponNames.Length) //if option is a statUp
        {
            Debug.Log(buttons[i]);
            //int stat = buttons[i] - (data.itemNames.Length + data.weaponNames.Length);
            if (buttons[i] == data.itemNames.Length + data.weaponNames.Length)
            {
                float healthUp = player.health / player.maxHealth;
                player.maxHealth += 50;
                player.health = healthUp * player.maxHealth;
            }
            if (buttons[i] == data.itemNames.Length + data.weaponNames.Length + 1) player.attack++;
            if (buttons[i] == data.itemNames.Length + data.weaponNames.Length + 1 + 1) player.moveSpeed++;
            if (buttons[i] == data.itemNames.Length + data.weaponNames.Length + 1 + 1 + 1) player.criticalChance++;
            if (buttons[i] == data.itemNames.Length + data.weaponNames.Length + 1 + 1 + 1 + 1) player.haste++;
            if (buttons[i] == data.itemNames.Length + data.weaponNames.Length + 1 + 1 + 1 + 1 + 1) player.pickupRange++;
            else player.luck++;
        }
        else
        {
            player.skills[buttons[i] - (data.statUpNames.Length + data.itemNames.Length + data.weaponNames.Length)]++;
        }
        levelUpCanvasGroup.alpha = 0;
        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Option1Chosen()
    {
        OptionChosen(0);
    }
    public void Option2Chosen()
    {
        OptionChosen(1);
    }
    public void Option3Chosen()
    {
        OptionChosen(2);
    }
    public void Option4Chosen()
    {
        OptionChosen(3);
    }
}