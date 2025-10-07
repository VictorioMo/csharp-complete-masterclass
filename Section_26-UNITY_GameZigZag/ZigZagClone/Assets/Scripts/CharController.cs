using UnityEngine;

public class CharController : MonoBehaviour
{
    public Transform rayStart;
    public GameObject crystalEffect;

    Rigidbody rb;
    bool walkingRight = true;
    Animator anim;
    GameManager gameManager;
    float moveSpeed = 1.5f;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.GameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger("IsIdle");
        }

        if (gameManager.score != 0)
        {
            moveSpeed = 1.5f + (float)gameManager.score / 15f;
        }

        rb.transform.position = transform.position + transform.forward * moveSpeed * Time.deltaTime;
    }

    void Update()
    {
        if (!gameManager.GameStarted)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchDirection();
        }

        RaycastHit hit;
        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            anim.SetTrigger("IsFalling");
        }

        if (transform.position.y < -3)
        {
            gameManager.EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Crystal")
        {
            gameManager.IncreaseScore();

            GameObject crystalTakenEffect = Instantiate(crystalEffect, transform.position, Quaternion.identity);
            Destroy(crystalTakenEffect, 0.5f);
            Destroy(other.gameObject);

        }
    }

    void SwitchDirection()
    {
        walkingRight = !walkingRight;

        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }
}
