using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpotSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Reference to the prefab
    public float spawnInterval = 1f; // Time between spawns
    public float minX = -8f; // Min X position for spawn
    public float maxX = 8f; // Max X position for spawn
    public float spawnY = 7f; // Y position for spawn (just above the screen)

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnInterval); // Wait for the next spawn
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
