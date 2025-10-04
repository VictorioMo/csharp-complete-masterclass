using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    int ScorePlayer1 = 0;
    int ScorePlayer2 = 0;

    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    public int goalToWin;

    private void Update()
    {
        if (ScorePlayer1 >= goalToWin || ScorePlayer2 >= goalToWin)
        {
            Debug.Log("Game won");
            SceneManager.LoadScene("GameOver");
        }
    }

    private void FixedUpdate()
    {
        Text uiScorePlayer1 = scoreTextPlayer1.GetComponent<Text>();
        uiScorePlayer1.text = ScorePlayer1.ToString();

        Text uiScorePlayer2 = scoreTextPlayer2.GetComponent<Text>();
        uiScorePlayer2.text = ScorePlayer2.ToString();
    }

    public void IncreaseGoalCountPlayer1()
    {
        ScorePlayer1++;
    }

    public void IncreaseGoalCountPlayer2()
    {
        ScorePlayer2++;
    }
}
