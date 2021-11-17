using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    enum ActiveScene
    {
        MENU, SETTINGS, CREDITS, EXIT, PLAY
    };

    ActiveScene activeScene;

    [SerializeField]
    GameObject menuGroup;
    [SerializeField]
    GameObject settingsGroup;
    [SerializeField]
    GameObject creditsGroup;

    bool firstWindow;

    [SerializeField]
    GameObject firstImage;

    void Start()
    {
        firstWindow = true;

        menuGroup.SetActive(false);
        settingsGroup.SetActive(false);
        creditsGroup.SetActive(false);
    }

    void Update()
    {
        if (firstWindow)
        {
            firstImage.SetActive(true);

            if (Input.GetKey(KeyCode.Return))
            {
                firstWindow = false;
            }
        }
        else
        {
            firstImage.SetActive(false);
        }

        switch (activeScene)
        {
            case ActiveScene.MENU:
                Menu();
                break;
            case ActiveScene.SETTINGS:
                Settings();
                break;
            case ActiveScene.CREDITS:
                Credits();
                break;
            case ActiveScene.EXIT:
                Application.Quit();
                break;
            case ActiveScene.PLAY:
                Play();
                break;
            default:
                break;
        }
    }


    void Menu()
    {
        menuGroup.SetActive(true);
        settingsGroup.SetActive(false);
        creditsGroup.SetActive(false);
    }
    void Settings()
    {
        settingsGroup.SetActive(true);
        menuGroup.SetActive(false);
        creditsGroup.SetActive(false);
    }
    void Credits()
    {
        creditsGroup.SetActive(true);
        menuGroup.SetActive(false);
        settingsGroup.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("J1");
    }


    public void MenuSelect()
    {
        activeScene = ActiveScene.MENU;
    }
    public void SettingsSelect()
    {
        activeScene = ActiveScene.SETTINGS;
    }
    public void CreditsSelect()
    {
        activeScene = ActiveScene.CREDITS;
    }
    public void ExitSelect()
    {
        activeScene = ActiveScene.EXIT;
    }

}
