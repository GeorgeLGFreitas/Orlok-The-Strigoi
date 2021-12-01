using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    enum GameOverOptions { MAINMENU, EXIT }

    GameOverOptions gameOverOptions;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void Update()
    {
        switch (gameOverOptions)
        {
            case GameOverOptions.MAINMENU:
                //SceneManager.LoadScene("MainMenu");
                break;
            case GameOverOptions.EXIT:
                //Application.Quit();
                break;
        }
    }
    public void MainMenuSelect()
    {
        SceneManager.LoadScene("MainMenu");
        //gameOverOptions = GameOverOptions.MAINMENU;
    }
    public void ExitSelect()
    {
        Application.Quit();
        //gameOverOptions = GameOverOptions.EXIT;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("J1");
    }
}
