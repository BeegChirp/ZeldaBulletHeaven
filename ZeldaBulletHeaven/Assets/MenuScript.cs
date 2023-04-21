using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public bool pauseBool = false;
    public GameObject pauseMenuUI;
    public TextMeshProUGUI timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
    public GameObject levelUpScreen;

    private void Update()
    {
        UpdateTimerUI();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseBool == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;
        while(secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = secondsCount - 60;
        }
        while(minuteCount >= 60)
        {
            hourCount++;
            minuteCount = minuteCount - 60;
        }
        if (hourCount > 0)
        {
            if (secondsCount < 10)
            {
                if (minuteCount < 10)
                {
                    timerText.text = hourCount + ":0" + minuteCount + ":0" + (int)secondsCount;
                }
                else
                {
                    timerText.text = hourCount + ":" + minuteCount + ":0" + (int)secondsCount;
                }
            }
            else
            {
                if (minuteCount < 10)
                {
                    timerText.text = hourCount + ":0" + minuteCount + ":" + (int)secondsCount;
                }
                else
                {
                    timerText.text = hourCount + ":" + minuteCount + ":" + (int)secondsCount;
                }
            }
        }
        else
        {
            if(secondsCount < 10)
            {
                if(minuteCount < 10)
                {
                    timerText.text = "0" + minuteCount + ":0" + (int)secondsCount;
                }
                else
                {
                    timerText.text = minuteCount + ":0" + (int)secondsCount;
                }
            }
            else
            {
                if (minuteCount < 10)
                {
                    timerText.text = "0" + minuteCount + ":" + (int)secondsCount;
                }
                else
                {
                    timerText.text = minuteCount + ":" + (int)secondsCount;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(Time.deltaTime);
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pauseBool = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pauseBool = true;
    }

    public void levelUp()
    {
        levelUpScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void optionChosen()
    {
        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
