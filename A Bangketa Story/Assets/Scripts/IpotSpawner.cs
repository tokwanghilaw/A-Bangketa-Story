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
    public float fallingSpeed = 1f; // Speed at which obstacles fall

    public ScoreManager scoreManager; // Reference to the ScoreManager
    private int scoreThreshold = 5; // Threshold to increase speed every 10 points
    private int currentThreshold = 5; // Tracks the next score to hit for increased speed

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            Spawn();
            AdjustDifficulty(); // Check if the difficulty needs to be increased
            yield return new WaitForSeconds(spawnInterval); // Wait for the next spawn
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        
        // Apply falling speed to the obstacle (assuming it has a Rigidbody2D)
        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(0, -fallingSpeed); // Make it fall at the defined speed
        }
    }

    void AdjustDifficulty()
    {
        if (scoreManager != null && scoreManager.GetScore() >= currentThreshold)
        {
            // Increase difficulty every time the score passes a multiple of 5
            spawnInterval = Mathf.Max(0.05f, spawnInterval * 0.5f); // Reduce spawn interval, minimum 0.5 seconds
            fallingSpeed += 1f; // Increase falling speed
            currentThreshold += scoreThreshold; // Set the next score threshold
        }
    }
}
