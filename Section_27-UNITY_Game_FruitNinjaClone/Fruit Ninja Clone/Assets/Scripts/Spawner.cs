using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform[] spawnPlaces;
    public float minWait = 0.3f;
    public float maxWait = 1.0f;
    public float minForce = 12f;
    public float maxForce = 17f;

    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    private IEnumerator SpawnFruits()
    {   
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));

            Transform spawnPlace = spawnPlaces[Random.Range(0, spawnPlaces.Length)];

            GameObject fruit = null;

            float chance = Random.Range(0, 100);
            int objectIndex = 0;

            if (chance < 10)
            {
                objectIndex = 0;
            }
            else
            {
                objectIndex = Random.Range(1, objectsToSpawn.Length);
            }

            fruit = Instantiate(objectsToSpawn[objectIndex], spawnPlace.position, spawnPlace.rotation);

            Vector2 force = Random.Range(minForce, maxForce) * fruit.transform.up;

            fruit.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);

            Debug.Log("Fruit spawned");

            Destroy(fruit, 5f);
        }
    }

}
