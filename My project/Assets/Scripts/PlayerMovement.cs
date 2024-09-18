using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variable to control the movement speed
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Check for left/right input
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Move the player to the left by adjusting the position
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // Move the player to the right by adjusting the position
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}