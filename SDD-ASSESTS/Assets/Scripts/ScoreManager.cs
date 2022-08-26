using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMPro.TMP_Text redScoreText;
    public TMPro.TMP_Text yellowScoreText;

    int redScore = 21;
    int yellowScore = 21;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        redScoreText.text = redScore.ToString();
        yellowScoreText.text = yellowScore.ToString();
    }

    // Decreases points for player 1
    public void redDecreasePoints()
    {
        redScore -= 1;
        redScoreText.text = redScore.ToString();
    }

    // Decreases points for player 2
    public void yellowDecreasePoints()
    {
        yellowScore -= 1;
        yellowScoreText.text = yellowScore.ToString();
    }
}

