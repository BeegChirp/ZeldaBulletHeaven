using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScript : MonoBehaviour
{
    public GameObject levelUpScreen;
    public CanvasGroup levelUpCanvasGroup;
    public DataBase data;
    public PlayerScript player;
    int[] buttons = new int[4];
    string[] buttonsDisplay;
    private void Start()
    {
        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x] = -1;
        }
    }
    public void levelUp()
    {
        /*for (int i = 0; i < buttons.Length; i++)
        {
            while (buttons[i] == -1)
            {
                int randomOption = Random.Range(0,16);

                    //THIS IS PROBABLY BAD

                if(randomOption <= 4)
                {
                    buttonsDisplay[i] = data.weaponNames[Random.Range(0, data.weaponNames.Length)]; //weapon
                }
                else if(randomOption <= 9)
                {
                    buttonsDisplay[i] = data.itemNames[Random.Range(0, data.weaponNames.Length)]; //item
                }
                else if(randomOption <= 14)
                {
                    buttonsDisplay[i] = data.skillNames[Random.Range(0, data.weaponNames.Length)]; //skill
                }
                else
                {
                    buttonsDisplay[i] = data.statUpNames[Random.Range(0, data.weaponNames.Length)]; //statUp
                }

                    //NEED TO FIND A WAY TO DETERMINE THE DIFFERENCE BETWEEN WEAPON X, ITEM X, SKILL X, AND STAT UP X

                if (i == 0 || randomOption != buttons[0] && randomOption != buttons[1] && randomOption != buttons[2])
                {
                    if (player.acquiredStuff[randomOption] < 6)
                    {
                        if (player.acquiredStuff[randomOption] < 0 && rerolled == false)
                        {
                            
                        }
                    }
                    else currentOptions.RemoveAt(randomOption);
                }
                else
                {
                    buttons[i] = -1;
                }
            }
        }*/
        levelUpCanvasGroup.alpha = 1;
        Time.timeScale = 0f;
    }
    public void optionChosen()
    {
        levelUpCanvasGroup.alpha = 0;
        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}