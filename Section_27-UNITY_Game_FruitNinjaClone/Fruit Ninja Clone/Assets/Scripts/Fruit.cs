using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateSlicedFruit();
        }
    }

    public void CreateSlicedFruit()
    {
        GameObject slicedFruit = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] slicedFruitParts = slicedFruit.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody slice in slicedFruitParts)
        {
            slice.transform.rotation = UnityEngine.Random.rotation;
            slice.AddExplosionForce(UnityEngine.Random.Range(500, 1000), transform.position, 5f);
        }

        IncreaseScore();

        Destroy(gameObject);
        Destroy(slicedFruit, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();

        if (b != null)
        {
            CreateSlicedFruit();
        }
        else
        {
            return;
        }
    }

    private void IncreaseScore()
    {
        string fruitName = gameObject.name;
        int score = 0;

        switch(fruitName)
        {
            case "Watermelon(Clone)":
            {
                score = 1;
                break;
            }

            case "Banana(Clone)":
            {
                score = 2;
                break;
            }
            case "Orange(Clone)":
            {
                score = 3;
                break;
            }

            default:
            {
                try
                {
                    new Exception("Unknown fruit.");
                }
                catch (Exception ex)
                {
                    Debug.Log(ex.Message);
                }
                finally
                {
#pragma warning disable CS0618 // Type or member is obsolete
                        FindObjectOfType<GameManager>().BombHit();
#pragma warning restore CS0618 // Type or member is obsolete
                    }
                    break;
            }
        }

#pragma warning disable CS0618 // Type or member is obsolete
        FindObjectOfType<GameManager>().IncreaseScore(score);
#pragma warning restore CS0618 // Type or member is obsolete
    }

}
