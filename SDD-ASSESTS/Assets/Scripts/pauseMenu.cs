using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject connect4Objects;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                resumeGame();
            }

            else
            {
                pauseGame();
            }
        }
    }

    public void resumeGame()
    {
        pauseMenuUI.SetActive(false);
        connect4Objects.SetActive(true);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void pauseGame()
    {
        pauseMenuUI.SetActive(true);
        connect4Objects.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void restartGame()
    {
        pauseMenuUI.SetActive(false);
        connect4Objects.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void goToMainMenu()
    {
        pauseMenuUI.SetActive(false);
        connect4Objects.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
