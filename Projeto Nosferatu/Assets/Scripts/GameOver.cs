using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    enum GameOverOptions { MAINMENU, EXIT }

    GameOverOptions gameOverOptions;

    private void Update()
    {
        switch (gameOverOptions)
        {
            case GameOverOptions.MAINMENU:
                SceneManager.LoadScene("MainMenu");
                break;
            case GameOverOptions.EXIT:
                Application.Quit();
                break;
        }
    }

    public void MainMenuSelect()
    {
        gameOverOptions = GameOverOptions.MAINMENU;
    }
    public void ExitSelect()
    {
        gameOverOptions = GameOverOptions.EXIT;
    }
}
