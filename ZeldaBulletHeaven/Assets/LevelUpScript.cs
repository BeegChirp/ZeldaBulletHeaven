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
            while(buttons[i] == -1)
            {
                int randomOption = data.levelUpOptions[Random.Range(0, data.levelUpOptions.Length)];
                if(i == 0 || randomOption != buttons[0] && randomOption != buttons[1] && randomOption != buttons[2])
                {
                    for (int z = 0; z < ; z++)
                    {

                    }
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