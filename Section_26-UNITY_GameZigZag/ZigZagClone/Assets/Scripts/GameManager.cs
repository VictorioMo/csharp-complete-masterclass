using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool GameStarted;
    public int score;
    public Text startText;
    public Text scoreText;
    public Text highScoreText;

    private void Awake()
    {
        startText.gameObject.SetActive(true);
        scoreText.text = score.ToString();

        highScoreText.text = "Best: " + GetHighScore().ToString();
    }

    public void StartGame()
    {
        GameStarted = true;
        startText.gameObject.SetActive(false);
        FindObjectOfType<RoadGenerator>().StartBuilder();
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = "Best: " + score.ToString();
        }
    }

    int GetHighScore()
    {
        int hscore = PlayerPrefs.GetInt("Highscore");

        return hscore;
    }
}
