using UnityEngine;

public class CheckForObjects : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        //if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
        //{
        //    print("we hit something at" + hit.transform.position);
        //}

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            print("hit " + hit.collider.gameObject.name);
        }
    }
}
