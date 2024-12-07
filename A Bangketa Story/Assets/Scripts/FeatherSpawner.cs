using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherSpawner : MonoBehaviour
{
    public GameObject obstacleObject; // Reference to the prefab
    public float timeBetweenDrops = 1f; // Time between spawns
    public float minSpawnX = -8f; // Min X position for spawn
    public float maxSpawnX = 8f; // Max X position for spawn
    public float spawnHeight = 7f; // Y position for spawn (just above the screen)
    public float minAngle = 0f; // Minimum rotation angle
    public float maxAngle = 360f; // Maximum rotation angle

    private void Start()
    {
        StartCoroutine(DropObstacles());
    }

    IEnumerator DropObstacles()
    {
        while (true)
        {
            CreateObstacle();
            yield return new WaitForSeconds(timeBetweenDrops); // Wait for the next spawn
        }
    }

    void CreateObstacle()
    {
        float randomXPos = Random.Range(minSpawnX, maxSpawnX);
        Vector2 spawnLocation = new Vector2(randomXPos, spawnHeight);

        // Generate a random rotation for the obstacle
        float randomRotationZ = Random.Range(minAngle, maxAngle);
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, randomRotationZ);

        // Instantiate the obstacle with a random rotation
        Instantiate(obstacleObject, spawnLocation, randomRotation);
    }
}
