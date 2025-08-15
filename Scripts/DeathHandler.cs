using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void HandleDeath()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0f; // Pause the game
        Cursor.visible = true; // Show the cursor
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Debug.Log("Game Over!"); // For debugging purposes
    }
}
