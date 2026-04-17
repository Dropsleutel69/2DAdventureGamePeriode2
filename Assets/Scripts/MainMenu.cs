using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //this method is called when the player presses the "Start Game" button
    public void StartGame()
    {
        //Load the scene called "GameScene" (Level 1)
        SceneManager.LoadScene("GameScene");
    }

    //this method is called when the player presses the "Quit" button
    public void QuitGame()
    {
        //Close the application (Doesnt work cause just play my game(AKA bug))
        Application.Quit();
    }

}
