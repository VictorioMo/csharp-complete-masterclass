using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayButton : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Play Game pressed");
        SceneManager.LoadScene("Game");
    }
}
