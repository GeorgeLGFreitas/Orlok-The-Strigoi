using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    enum Pause
    {
        UNPAUSED,PAUSED, SETTINGS, CONTROLS, MENU, EXIT
    };

    Pause pause;

    [SerializeField]
    GameObject pausedGroup;
    [SerializeField]
    GameObject settingsGroup;
    [SerializeField]
    GameObject controlsGroup;

    public bool pausado;

    void Start()
    {
        pause = Pause.UNPAUSED;
        Cursor.lockState = CursorLockMode.None;  
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
            case Pause.CONTROLS:

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
    }

    void UnPaused()
    {
        Cursor.lockState = CursorLockMode.Locked;  
        pausado = false;
        Time.timeScale = 1;
        pausedGroup.SetActive(false);
        settingsGroup.SetActive(false);
        controlsGroup.SetActive(false);
    }
    void Paused()
    {
        Cursor.lockState = CursorLockMode.None;   
        pausado = true;
        Time.timeScale = 0;
        pausedGroup.SetActive(true);
        controlsGroup.SetActive(false);
        settingsGroup.SetActive(false);
    }
    void Settings()
    {
        pausedGroup.SetActive(false);
        controlsGroup.SetActive(false);
        settingsGroup.SetActive(true);
    }
    void Controls()
    {
        pausedGroup.SetActive(false);
        settingsGroup.SetActive(false);
        controlsGroup.SetActive(true);

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
    public void ControlsSelect()
    {
        pause = Pause.CONTROLS;
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
