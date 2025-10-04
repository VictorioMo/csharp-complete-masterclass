using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Trigger");
        Destroy(gameObject);
    }
}
