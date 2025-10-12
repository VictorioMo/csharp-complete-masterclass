using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int Score = 0;
    public int HighScore;
    public Text ScoreText;
    public Text HighScoreText;

    [Header("Game Over Panel")]
    public GameObject gameOverPanel;
    public Text gameOverTextScore;
    public Text gameOverTextHighScore;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
        HighScore = PlayerPrefs.GetInt("HighScore");
        HighScoreText.text = $"Best: {HighScore.ToString()}";
    }

    public void IncreaseScore(int points)
    {
        Score += points;
        ScoreText.text = Score.ToString();
    }

    public void BombHit()
    {
        Time.timeScale = 0;
        gameOverTextScore.text = $"Score: {Score.ToString()}";

        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt("HighScore", HighScore);
            HighScoreText.text = $"Best: {HighScore.ToString()}";
        }

        gameOverTextHighScore.text = HighScoreText.text;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Score = 0;
        ScoreText.text = "0";
        gameOverPanel.SetActive(false);
        gameOverTextScore.text = "Score: 0";

        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(g);
        }

        Time.timeScale = 1;
    }
}
