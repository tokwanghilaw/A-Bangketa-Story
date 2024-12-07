using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherCollision : MonoBehaviour
{
    public float vanishThreshold = -5f; // Y-coordinate threshold for destruction
    private ScoreManager scoreManager;
    public float slowEffectDuration = 5f; // Duration of the slow effect
    public float speedReductionFactor = 0.5f; // Factor to reduce the player's speed
    private bool isSlowed = false; // Flag to check if the player is already slowed

    private void Start()
    {
        // Find the ScoreManager in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        // Check if the object's Y position is less than the specified threshold
        if (transform.position.y <= vanishThreshold) 
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
            // Apply slow effect to the player
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            if (playerMovement != null && !isSlowed) // Only apply if not already slowed
            {
                StartCoroutine(ApplySlowEffect(playerMovement));
            }

            // Destroy the falling object
            Destroy(gameObject);
        }
    }

    private IEnumerator ApplySlowEffect(PlayerMovement playerMovement)
    {
        isSlowed = true; // Set the flag to true to indicate the player is slowed

        // Reduce the player's speed by the slow effect factor
        playerMovement.speed *= speedReductionFactor;

        // Wait for the slow effect duration
        yield return new WaitForSeconds(slowEffectDuration);

        // Restore the player's original movement speed
        playerMovement.speed /= speedReductionFactor;

        isSlowed = false; // Reset the flag after the effect is done
    }
}
