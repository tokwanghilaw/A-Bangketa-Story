using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectCollision : MonoBehaviour
{
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
