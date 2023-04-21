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
    public GameObject levelUpScreen;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseBool)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void FixedUpdate()
    {
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
