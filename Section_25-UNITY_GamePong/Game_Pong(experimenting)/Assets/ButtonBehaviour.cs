using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Level1");
    }
}
