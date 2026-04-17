using UnityEngine;

public class NextLevel : MonoBehaviour
{
    // Name of the next scene to load
    public string nextLevelName;

    // This method is called when the player proceeds to the next level
    public void LoadNextLevel()
    {
        // Load the next level using the scene name
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);

        // Ensure the game is not paused
        Time.timeScale = 1;
    }
}