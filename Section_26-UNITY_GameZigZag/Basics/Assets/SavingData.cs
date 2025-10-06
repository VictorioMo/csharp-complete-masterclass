using UnityEngine;

public class SavingData : MonoBehaviour
{
    int number = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"Get stored data: {GetNumber()}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            number++;
            if (number > GetNumber())
            {
                PlayerPrefs.SetInt("MyNumber", number);
                Debug.Log(number);
            }
        }
    }

    int GetNumber()
    {
        int score_loc = PlayerPrefs.GetInt("MyNumber", 0);

        return score_loc;
    }
}
