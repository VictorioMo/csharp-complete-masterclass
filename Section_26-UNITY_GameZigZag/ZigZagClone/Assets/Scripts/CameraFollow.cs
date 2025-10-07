using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;

    void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}