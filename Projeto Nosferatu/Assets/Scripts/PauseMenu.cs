using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    enum Pause
    {
        UNPAUSED,PAUSED, SETTINGS, MENU, EXIT
    };

    Pause pause;

    [SerializeField]
    GameObject pausedGroup;
    [SerializeField]
    GameObject settingsGroup;

    void Start()
    {
        pause = Pause.UNPAUSED;
    }

    void Update()
    {
        switch (pause)
        {
            case Pause.UNPAUSED:
                UnPaused();
                break;
            case Pause.PAUSED:
                Paused();
                break;
            case Pause.SETTINGS:
                Settings();
                break;
            case Pause.MENU:
                Menu();
                break;
            case Pause.EXIT:
                Application.Quit();
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == Pause.PAUSED)
            {
                pause = Pause.UNPAUSED;
            }
            else
            {
                pause = Pause.PAUSED;
            }
        }
        Debug.Log(Time.deltaTime);
    }

    void UnPaused()
    {
        Time.timeScale = 1;
        pausedGroup.SetActive(false);
        settingsGroup.SetActive(false);
    }
    void Paused()
    {
        Time.timeScale = 0;
        pausedGroup.SetActive(true);
        settingsGroup.SetActive(false);
    }
    void Settings()
    {
        pausedGroup.SetActive(false);
        settingsGroup.SetActive(true);
    }
    void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void UnPauseSelect()
    {
        pause = Pause.UNPAUSED;
    }
    public void PauseSelect()
    {
        pause = Pause.PAUSED;
    }
    public void SettingsSelect()
    {
        pause = Pause.SETTINGS;
    }
    public void MenuSelect()
    {
        pause = Pause.MENU;
    }
    public void ExitSelect()
    {
        pause = Pause.EXIT;
    }
}
