using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private bool isMoving = false;

    public float minX = -8.5f; // Left boundary
    public float maxX = 8.5f;  // Right boundary

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //arrow keys
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            if (!isMoving)
            {
                // insert play walk animation
                Debug.Log("Player started moving.");
            }
            isMoving = true;
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
        else
        {
            if (isMoving)
            {
                // insert stop animation
                Debug.Log("Player stopped moving.");
            }
            isMoving = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // player's position to be within the screen boundaries
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
