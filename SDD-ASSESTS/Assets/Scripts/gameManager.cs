using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject[] spawnLocations;
    public GameObject winScreen;

    public TMPro.TMP_Text winText;

    public int boardHeight = 6;
    public int boardLength = 7;

    bool player1Turn = true;
    bool hasPlayerWon = false;

    int[,] boardState;

    // Plays at start of scene
    void Start()
    {
        boardState = new int[boardLength, boardHeight];
    }

    // Checks which column chip should be in 
    public void selectColumn(int columnCheck)
    {
        takeTurn(columnCheck);
    }

    // Changes turn of players on click
    void takeTurn(int columnCheck)
    {
        if (updateBoard(columnCheck))
        {
            if (player1Turn)
            {
                Instantiate(player1, spawnLocations[columnCheck].transform.position, Quaternion.identity);
                ScoreManager.instance.redDecreasePoints();
                player1Turn = false;

                // If player 1 wins
                if (gameFinished(1))
                {
                    hasPlayerWon = true;
                    winScreen.SetActive(true);

                    winText.text = "PLAYER 1 HAS WON!";
                    winText.color = Color.red;
                }
            }

            else
            {
                Instantiate(player2, spawnLocations[columnCheck].transform.position, Quaternion.identity);
                ScoreManager.instance.yellowDecreasePoints();
                player1Turn = true;

                // If player 2 wins
                if (gameFinished(2))
                {
                    hasPlayerWon = true;            
                    winScreen.SetActive(true);

                    winText.text = "PLAYER 2 HAS WON!";
                    winText.color = Color.yellow;
                }
            }  

            // If neither player wins
            if (gameDraw())
            {
                hasPlayerWon = true;
                winScreen.SetActive(true);

                winText.text = "DRAW!";
                winText.color = Color.black;
            }
        }

    }

    // Where the chip is in realtion to the board
    bool updateBoard(int columnCheck)
    {
        for (int row = 0; row < boardHeight; row++)
        {
            if (boardState[columnCheck, row] == 0)
            {
                if (player1Turn)
                {
                    boardState[columnCheck, row] = 1;
                }

                else
                {
                    boardState[columnCheck, row] = 2;
                }
                return true;
            }
        }
        return false;
    }
    
    // Check if player won and how the won
    bool gameFinished(int playerNum)
    {
        // Horizontal win check
        for (int x = 0; x < boardLength - 3; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                if (boardState[x, y] == playerNum && boardState[x + 1, y] == playerNum && boardState[x + 2, y] == playerNum && boardState[x + 3, y] == playerNum)
                {      
                    return true;
                }
            }
        }

        // Vertical win check
        for (int x = 0; x < boardLength; x++)
        {
            for (int y = 0; y < boardHeight - 3; y++)
            {
                if (boardState[x, y] == playerNum && boardState[x, y + 1] == playerNum && boardState[x, y + 2] == playerNum && boardState[x, y + 3] == playerNum)
                {
                    return true;
                }
            }
        }

        // Left diagonal win check 
        for (int x = 0; x < boardLength - 3; x++)
        {
            for (int y = 0; y < boardHeight - 3; y++)
            {
                if (boardState[x, y] == playerNum && boardState[x + 1, y + 1] == playerNum && boardState[x + 2, y + 2] == playerNum && boardState[x + 3, y + 3] == playerNum)
                { 
                    return true;
                }
            }
        }

        // Right diagonal win check
        for (int x = 0; x < boardLength - 3; x++)
        {
            for (int y = 0; y < boardHeight - 3; y++)
            {
                if (boardState[x, y + 3] == playerNum && boardState[x + 1, y + 2] == playerNum && boardState[x + 2, y + 1] == playerNum && boardState[x + 3, y] == playerNum)
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool gameDraw()
    {
        for (int x = 0; x < boardLength; x++)
        {
            if (boardState[x, boardHeight - 1] == 0)
            {
                return false;
            }
        }
        return true;
    }
}