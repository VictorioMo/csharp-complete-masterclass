using UnityEngine;

public class InstantinateCubes : MonoBehaviour
{
    public Transform prefab;
    int counter = 0;
    int counter_task = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 10;  i++)
        {
            Instantiate(prefab, new Vector3(i * 3.0f, 0, 0), Quaternion.identity);
        }

        InvokeRepeating("CreateCube", 3f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (counter % 2 == 0)
            {
                Instantiate(prefab, new Vector3(counter * 3.0f, 0, -5), Quaternion.identity);
            }
            else
            {
                Instantiate(prefab, new Vector3(counter * 3.0f, 0, -7), Quaternion.identity);
            }
            counter++;
        }
    }

    public void CreateCube()
    {
        Instantiate(prefab, new Vector3(counter_task * 3.0f, 0, 5), Quaternion.identity);
        counter_task++;

        if(counter_task >= 5)
        {
            CancelInvoke();
        }
    }
}
