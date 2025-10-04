using UnityEngine;

public class RacketPlayer2 : MonoBehaviour
{
    public float movementSpeed;

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Vertical2");

        GetComponent<Rigidbody2D>().linearVelocity = new Vector2 (0, v) * movementSpeed;
    }

}
