using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Reference to the pause menu UI container
    public GameObject container;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //This method is called when the resume button is pressed
    public void RestumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }

    //this method is called when the Main menu button is pressed
    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu");
    }
}
