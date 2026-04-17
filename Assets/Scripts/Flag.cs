using UnityEngine;

public class Flag : MonoBehaviour
{
    // Reference to the UI that appears when the player wins
    public GameObject winUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player reached the flag
        if (collision.gameObject.tag == "Player")
        {
            // Pause the game
            Time.timeScale = 0;

            // Show the win screen UI
            winUI.SetActive(true);
        }
    }
}