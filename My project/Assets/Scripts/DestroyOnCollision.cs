using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has the tag "FallingObject"
        if (other.CompareTag("FallingObject"))
        {
            // Destroy the falling object
            Destroy(other.gameObject);
        }
    }
}
