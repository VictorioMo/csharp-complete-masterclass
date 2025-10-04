using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public BallMovement BallMovement;
    public ScoreController ScoreController;

    void BounceFromRacket(Collision2D c)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = c.gameObject.transform.position;

        float racketHeight = c.collider.bounds.size.y;

        float x;
        if (c.gameObject.name == "RacketPlayer1")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }

        float y = (ballPosition.y - racketPosition.y) / racketHeight;

        BallMovement.IncreaseHitCounter();
        BallMovement.MoveBall(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string otherColliderName = collision.gameObject.name;

        if (otherColliderName == "RacketPlayer1" || otherColliderName == "RacketPlayer2")
        {
            BounceFromRacket(collision);
        }
        else if (otherColliderName == "WallLeft")
        {
            Debug.Log("Left wall hit");
            ScoreController.IncreaseGoalCountPlayer2();
            StartCoroutine(BallMovement.StartBall(true));
        }
        else if (otherColliderName == "WallRight")
        {
            Debug.Log("Right wall hit");
            ScoreController.IncreaseGoalCountPlayer1();
            StartCoroutine(BallMovement.StartBall(false));
        }
        else
        {
            // Nothing
        }
    }
}
