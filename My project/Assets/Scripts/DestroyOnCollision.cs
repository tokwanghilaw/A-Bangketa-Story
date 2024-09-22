using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    private ScoreManager ScoreManager;

    private void Start()
    {
        // Find the ScoreManager in the scene
        ScoreManager = FindObjectOfType<ScoreManager>();
    }

    // This method is called when another collider enters this trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered is a falling object (you can add tags if needed)
        if (gameObject.CompareTag("FallingObject")) 
        {
            // Add 1 point to the score
            ScoreManager.AddScore(1);

            // Destroy the falling object
            Destroy(other.gameObject);
        }
        Debug.Log("Object entered trigger: " + other.gameObject.name);
    }
}
