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
                weaponWeightList.Add(a);
            }
        }
        for (int a = 0; a < data.itemNames.Length; a++)
        {
            for (int b = 0; b < data.itemWeights[a]; b++)
            {
                itemWeightList.Add(a);
            }
        }
        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x] = -1;
        }
    }
    public void levelUp()
    {
        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x] = -1;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            while (buttons[i] == -1)
            {
                int randomCategory = Random.Range(0, 4);
                int randomOption;
                int placeholder;

                if (randomCategory == 0)
                {
                    placeholder = Random.Range(0, weaponWeightList.Count);
                    randomOption = weaponWeightList[placeholder];
                    buttonsDisplay[i] = data.weaponNames[randomOption]; //weapon
                    buttonText(i);
                }
                else if (randomCategory == 1)
                {
                    placeholder = Random.Range(0, itemWeightList.Count);
                    randomOption = itemWeightList[placeholder];
                    buttonsDisplay[i] = data.itemNames[randomOption]; //item
                    buttonText(i);
                    randomOption = randomOption + data.weaponWeights.Length;

                }
                else if (randomCategory == 2)
                {
                    randomOption = Random.Range(0, data.statUpNames.Length);
                    buttonsDisplay[i] = data.statUpNames[randomOption]; //statUp
                    buttonText(i);
                    randomOption = randomOption + data.weaponWeights.Length + data.itemWeights.Length;
                }
                else
                {
                    randomOption = Random.Range(0, player.skillNames.Length);
                    buttonsDisplay[i] = player.skillNames[randomOption]; //skill
                    buttonText(i);
                    randomOption = randomOption + data.weaponWeights.Length + data.itemWeights.Length + data.statUpWeights.Length;
                }

                //NEED TO FIND A WAY TO DETERMINE THE DIFFERENCE BETWEEN WEAPON X, ITEM X, SKILL X, AND STAT UP X
                if (i == 0 || randomOption != buttons[0] && randomOption != buttons[1] && randomOption != buttons[2])
                {
                    Debug.Log(randomOption);
                    buttons[i] = randomOption;
                    /*if (player.acquiredStuff[randomCategory] < 6)
                    {
                        if (player.acquiredStuff[randomCategory] < 0 && rerolled == false)
                        {

                        }
                    }*/
                }
                else
                {
                    buttons[i] = -1;
                }
            }
        }
        levelUpCanvasGroup.alpha = 1;
        Time.timeScale = 0f;
    }
    public void buttonText(int i)
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

    public void optionChosen(int i)
    {
        bool upgradeDone = false;
        if (buttons[i] < data.weaponNames.Length)
        {
            for (int a = 0; a < (player.weaponInventory.Length); a++)
            {
                if (a < (player.weaponInventory.Length / 2))
                {
                    if (buttons[i] == player.weaponInventory[a, 0])
                    {
                        player.weaponInventory[a, 1]++;
                        upgradeDone = true;
                    }
                }
                else if (upgradeDone == false)
                {
                    if (player.weaponInventory[(a - (player.weaponInventory.Length / 2)), 0] == -1)
                    {
                        player.weaponInventory[(a - (player.weaponInventory.Length / 2)), 0] = buttons[i];
                        player.weaponInventory[(a - (player.weaponInventory.Length / 2)), 1]++;
                        upgradeDone = true;
                    }
                }
            }
        }
        else if (buttons[i] < data.itemNames.Length + data.weaponNames.Length)
        {
            for (int b = 0; b < (player.itemInventory.Length); b++)
            {
                if (b < (player.itemInventory.Length / 2))
                {
                    if (buttons[i] == player.itemInventory[b, 0])
                    {
                        player.itemInventory[b, 1]++;
                        upgradeDone = true;
                    }
                }
                else if (upgradeDone == false)
                {
                    if (player.itemInventory[(b - (player.itemInventory.Length / 2)), 0] == -1)
                    {
                        player.itemInventory[(b - (player.itemInventory.Length / 2)), 0] = buttons[i];
                        player.itemInventory[(b - (player.itemInventory.Length / 2)), 1]++;
                        upgradeDone = true;
                    }
                }
            }
        }
        else if (buttons[i] < data.statUpNames.Length + data.itemNames.Length + data.weaponNames.Length)
        {
            //int stat = buttons[i] - data.itemNames.Length + data.weaponNames.Length;
            if (buttons[i] == 41)
            {
                float healthUp = player.health / player.maxHealth;
                player.maxHealth += 50;
                player.health = healthUp * player.maxHealth;
            }
            if (buttons[i] == 42) player.attack++;
            if (buttons[i] == 43) player.moveSpeed++;
            if (buttons[i] == 44) player.criticalChance++;
            if (buttons[i] == 45) player.haste++;
            if (buttons[i] == 46) player.pickupRange++;
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
    public void option1Chosen()
    {
        optionChosen(0);
    }
    public void option2Chosen()
    {
        optionChosen(1);
    }
    public void option3Chosen()
    {
        optionChosen(2);
    }
    public void option4Chosen()
    {
        optionChosen(3);
    }
}