using UnityEngine;

public class RacketPlayer1 : MonoBehaviour
{
    public float movementSpeed;

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical1");

        GetComponent<Rigidbody2D>().linearVelocity = new Vector2 (0, v) * movementSpeed;
    }

}
