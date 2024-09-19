using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private bool isMoving = false;

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
            isMoving = true;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else
        {
            // Stop player when no input
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Stop movement if player collides with a wall
        if (collision.gameObject.CompareTag("Poste"))
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
        }
    }
}
