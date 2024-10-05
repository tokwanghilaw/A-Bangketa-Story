using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpotCollision : MonoBehaviour
{
    public float destroyYThreshold = -5f; // Y-coordinate threshold for destruction
    private ScoreManager scoreManager;

    private void Start()
    {
        // Find the ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        // Check if the object's Y position is less than the specified threshold
        if (transform.position.y <= destroyYThreshold)
        {
            // Add 1 point to the score
            if (scoreManager != null)
            {
                scoreManager.AddScore(1);
                Debug.Log("Score updated for object: " + gameObject.name);
            }
            else
            {
                Debug.LogError("ScoreManager not found.");
            }

            // Destroy the falling object when it reaches the Y threshold
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object collided with has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy this falling object (the object this script is attached to)
            Destroy(gameObject);
        }
    }
}
