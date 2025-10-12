using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (b != null)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            FindObjectOfType<GameManager>().BombHit();
#pragma warning restore CS0618 // Type or member is obsolete
        }
        else
        {
            return;
        }
    }
}
