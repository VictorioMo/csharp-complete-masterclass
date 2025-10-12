using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minDistance = 0.25f;
    private Rigidbody2D rb;

    private Vector3 lastMousePos;
    private Vector3 mouseVel;

    private Collider2D col;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        lastMousePos = transform.position;
    }

    private void Update()
    {
        SetBladeOnMousePos();
    }

    void FixedUpdate()
    {
        col.enabled = IsMouseMoving();
    }

    private void SetBladeOnMousePos()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;

        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private bool IsMouseMoving()
    {
        bool retVal = false;
        Vector3 MousePos = transform.position;
        float d = (lastMousePos - MousePos).magnitude;
        lastMousePos = MousePos;

        if (d > minDistance)
        {
            retVal = true;
        }
        else
        {
            retVal = false;
        }

        return retVal;
    }
}
