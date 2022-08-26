using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class mainMenuControl : MonoBehaviour 
{
    public void PlayGame() 
    {
        SceneManager.LoadScene("Game");
    }
    
    public void LeaderboardMenu() 
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void LeaderboardToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GameToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GetName()
    {
        SceneManager.LoadScene("Get Name");
    }
}


