using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string otherColliderName = collision.gameObject.name;

        if (otherColliderName == "RacketPlayer1" || otherColliderName == "RacketPlayer2")
        {
            racketSound.Play();
        }
        else
        {
            wallSound.Play();
        }
    }
}
