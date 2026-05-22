using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject xenonitePrefab;
    public GameObject rockyPrefab;
    public GameObject astrophagePrefab;
    public GameObject asteroidPrefab;

    [Header("Spawn Settings")]
    public float spawnInterval = 1.2f;
    public float spawnX = 10f;
    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void SpawnObject()
    {
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(spawnX, randomY);

        int randomNum = Random.Range(0, 100);

        if (randomNum < 45)
        {
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        }
        else if (randomNum < 65)
        {
            Instantiate(astrophagePrefab, spawnPosition, Quaternion.identity);
        }
        else if (randomNum < 80)
        {
            Instantiate(rockyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(xenonitePrefab, spawnPosition, Quaternion.identity);
        }
    }
}