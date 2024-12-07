using UnityEngine;

public class HideCursor : MonoBehaviour
{
    void Start()
    {
        // Hide and lock the cursor
        Cursor.visible = false; // Hides the cursor
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen
    }

    void OnDestroy()
    {
        // Restore the cursor when the scene is exited
        Cursor.visible = true; // Makes the cursor visible again
        Cursor.lockState = CursorLockMode.None; // Releases the lock on the cursor
    }
}
