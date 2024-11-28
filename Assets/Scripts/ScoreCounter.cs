using System;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public int playerScore = 0;
    public int playerHighScore = 0;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Highscore;
    public void Start()
    {
        Score.text = ("Score: 0");
        Highscore.text = ("High Score: 0");

        if (PlayerPrefs.HasKey("playerHighScore") == true)
        {
            playerHighScore = PlayerPrefs.GetInt("playerHighScore");
        }
        else
        {
            PlayerPrefs.SetInt("playerHighScore", 0);
            playerHighScore = PlayerPrefs.GetInt("playerHighScore", playerHighScore);
        }
    }
    public void GainingPoints()
    {
        playerScore = playerScore + 10;
    }
    public void LosingPoints()
    {
        playerScore = playerScore - 10;
    }
    public void HighScore()
    {
        if (playerHighScore <= playerScore)
        {
            playerHighScore = playerScore;
            PlayerPrefs.SetInt("playerHighScore", playerHighScore);
        }
    }
    public void Update()
    {
        HighScore();
        Score.text = ("Score:" + playerScore);
        Highscore.text = ("High Score: " + playerHighScore);
    }
}
