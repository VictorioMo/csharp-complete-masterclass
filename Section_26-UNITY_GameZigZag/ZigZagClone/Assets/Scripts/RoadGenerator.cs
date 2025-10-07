using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject roadPrefab;
    public GameObject crystalPrefab;
    public Transform lastPos_tr;
    Vector3 lastPos;
    int crystalSpawnCounter = 1;

    float chance = 0;
    const float offset = 0.70711f;
    const float crystalOffset = 0.5f;

    public void StartBuilder()
    {
        lastPos = lastPos_tr.position;

        InvokeRepeating("CreateNewRoadPart", 1f, 0.2f);
    }

    public void CreateNewRoadPart()
    {
        Debug.Log("New road part created");

        Vector3 spawnPos = Vector3.zero;

        chance = Random.Range(0, 100);

        if (chance < 50)
        {
            spawnPos = new Vector3(lastPos.x + offset, lastPos.y, lastPos.z + offset);
        }
        else
        {
            spawnPos = new Vector3(lastPos.x - offset, lastPos.y, lastPos.z + offset);
        }

        GameObject roadPiece = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));
        lastPos = roadPiece.transform.position;

        Vector3 crystalSpawnPos = lastPos;
        crystalSpawnPos.y += crystalOffset;

        crystalSpawnCounter++;

        if (crystalSpawnCounter >= Random.Range(3, 16))
        {
            GameObject crystal = Instantiate(crystalPrefab, crystalSpawnPos, Quaternion.Euler(0, 45, 0));
            crystalSpawnCounter = 0;
        }
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    CreateNewRoadPart();
        //}
    }
}
