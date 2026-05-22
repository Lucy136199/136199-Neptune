using UnityEngine;
using System.Collections;

public class SpawnManager3 : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject xenonitePrefab;
    public GameObject rockyPrefab;
    public GameObject astrophagePrefab;
    public GameObject adrianmeteorPrefab;

    [Header("Spawn Settings")]
    public float spawnInterval = 1.2f;
    public float spawnX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        Debug.Log("SpawnManager3 started");
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObject()
    {
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(spawnX, randomY);

        int randomNum = Random.Range(0, 100);
        GameObject prefabToSpawn = null;

        if (randomNum < 45)
        {
            prefabToSpawn = adrianmeteorPrefab;
        }
        else if (randomNum < 65)
        {
            prefabToSpawn = astrophagePrefab;
        }
        else if (randomNum < 80)
        {
            prefabToSpawn = rockyPrefab;
        }
        else
        {
            prefabToSpawn = xenonitePrefab;
        }

        if (prefabToSpawn == null)
        {
            Debug.LogError("SpawnManager3: Prefab is missing.");
            return;
        }

        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        //Debug.Log("Spawned: " + prefabToSpawn.name);
    }
}