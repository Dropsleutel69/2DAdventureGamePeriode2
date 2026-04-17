using UnityEngine;

public class RestartGame : MonoBehaviour
{
    // This method is called when the restart button is pressed
    public void LoadCurrentScene()
    {
        // Load the game scene again (restart the level)
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");

        // Make sure time is running again (in case it was paused)
        Time.timeScale = 1;
    }
}