using UnityEngine;
using System.Collections;  // Add this line for IEnumerator support in coroutines

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private bool isMoving = false;
    public float minX = -8.5f; // Left boundary
    public float maxX = 8.5f; // Right boundary
    public float slowEffectDuration = 5f; // Duration of the slow effect
    public float speedReductionFactor = 0.5f; // Factor to reduce the player's speed
    private bool isSlowed = false; // Flag to check if the player is already slowed

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
        else if (collision.gameObject.GetComponent<FeatherCollision>() != null)
        {
            if (!isSlowed)
            {
                StartCoroutine(ApplySlowEffect());
            }
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator ApplySlowEffect()
    {
        isSlowed = true; // Set the flag to true to indicate the player is slowed
        float originalSpeed = speed;
        speed *= speedReductionFactor;
        // Wait for the slow effect duration
        yield return new WaitForSeconds(slowEffectDuration);
        // Restore the player's original movement speed
        speed = originalSpeed;
        isSlowed = false; // Reset the flag after the effect is done
    }
}