using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardEntryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI entryNameText;
    [SerializeField] private TextMeshProUGUI entryScoreText;

    public void Initialise(ScoreboardEntryData scoreboardEntryData)
    {
        entryNameText.text = scoreboardEntryData.entryName;
        entryScoreText.text = scoreboardEntryData.entryScore.ToString();
    }
}