using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    enum GameOverOptions { MAINMENU, EXIT }

    GameOverOptions gameOverOptions;

    public SceneLocator sceneL;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        sceneL = FindObjectOfType<SceneLocator>();
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
        
        if(sceneL.cenaF == 1)
        {
         SceneManager.LoadScene("J1");
        }
        if(sceneL.cenaF == 2)
        {
         SceneManager.LoadScene("Mapa 2");
        }
        
    }
}
