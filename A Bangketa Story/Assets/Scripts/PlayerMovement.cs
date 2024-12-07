using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private bool isMoving = false;

    // Define the screen boundaries (you can adjust these values)
    public float minX = -8.5f; // Left boundary
    public float maxX = 8.5f;  // Right boundary

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input from arrow keys (left/right)
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Move the player if the left or right arrow keys are pressed
        if (moveInput != 0)
        {
            if (!isMoving)
            {
                // Perform actions that should happen when movement starts (e.g., play animation)
                Debug.Log("Player started moving.");
            }
            isMoving = true;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else
        {
            if (isMoving)
            {
                // Perform actions that should happen when movement stops (e.g., stop animation)
                Debug.Log("Player stopped moving.");
            }
            isMoving = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Clamp the player's position to be within the screen boundaries
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        transform.position = clampedPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Stop movement if player collides with a wall
        if (collision.gameObject.CompareTag("Poste"))
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
            Debug.Log("Player collided with an object and stopped moving.");
        }
    }
}
