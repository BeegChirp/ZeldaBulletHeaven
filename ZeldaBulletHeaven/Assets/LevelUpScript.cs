using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpScript : MonoBehaviour
{
    public GameObject levelUpScreen;
    public CanvasGroup levelUpCanvasGroup;
    public DataBase data;
    public PlayerScript player;
    bool rerolled = false;
    int[] buttons = new int[4];
    int[] currentOptions;
    private void Start()
    {
        for (int x = 0; x < buttons.Length; x++)
        {
            buttons[x] = -1;
        }
        currentOptions = data.levelUpOptions;
    }
    public void levelUp()
    {
        /*for (int i = 0; i < buttons.Length; i++)
        {
            rerolled = false;
            while (buttons[i] == -1)
            {
                int randomOption = data.levelUpOptions[Random.Range(0, data.levelUpOptions.Length)];
                if (i == 0 || randomOption != buttons[0] && randomOption != buttons[1] && randomOption != buttons[2])
                {
                    if (player.acquiredStuff[randomOption] < 6)
                    {
                        if (player.acquiredStuff[randomOption] < 0 && rerolled == false)
                        {
                            rerolled = true;
                            reroll();
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

    public void reroll()
    {
        levelUp();
    }

    public void optionChosen()
    {
        levelUpCanvasGroup.alpha = 0;
        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}