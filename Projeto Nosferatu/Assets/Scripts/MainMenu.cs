using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    enum ActiveScene
    {
        MENU, SETTINGS, CREDITS, CONTROLS, EXIT, PLAY
    };

    ActiveScene activeScene;

    [SerializeField]
    GameObject menuGroup;
    [SerializeField]
    GameObject settingsGroup;
    [SerializeField]
    GameObject creditsGroup;
    [SerializeField]
    GameObject controlsGroup;
    [SerializeField]
    GameObject inicioFala1;
    [SerializeField]
    GameObject inicioFala2;
    [SerializeField]
    GameObject PainelFalas;

    bool firstWindow;
    public float timer;
    public float tempo;

    [SerializeField]
    GameObject firstImage;
    

    void Start()
    {
        firstWindow = true;

        menuGroup.SetActive(false);
        settingsGroup.SetActive(false);
        creditsGroup.SetActive(false);
        PainelFalas.SetActive(false);
        timer=tempo;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);

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
            case ActiveScene.CONTROLS:
                Controls();
                break;
            case ActiveScene.EXIT:
                Application.Quit();
                break;
            case ActiveScene.PLAY:
                Play();
                break;
        }
    }


    void Menu()
    {
        menuGroup.SetActive(true);
        settingsGroup.SetActive(false);
        creditsGroup.SetActive(false);
        PainelFalas.SetActive(false);
        controlsGroup.SetActive(false);
    }
    void Settings()
    {
        settingsGroup.SetActive(true);
        menuGroup.SetActive(false);
        creditsGroup.SetActive(false);
        PainelFalas.SetActive(false);
        controlsGroup.SetActive(false);
    }
    void Credits()
    {
        creditsGroup.SetActive(true);
        menuGroup.SetActive(false);
        settingsGroup.SetActive(false);
        PainelFalas.SetActive(false);
        controlsGroup.SetActive(false);
    }
    void Controls()
    {
        controlsGroup.SetActive(true);
        creditsGroup.SetActive(false);
        menuGroup.SetActive(false);
        settingsGroup.SetActive(false);
        PainelFalas.SetActive(false);
    }
    public void Play()
    {
        PainelFalas.SetActive(true);
        menuGroup.SetActive(false);
        settingsGroup.SetActive(false);
        creditsGroup.SetActive(false);
        controlsGroup.SetActive(false);


        bool one =true;
        bool two = false;

        if(one)
        {
            if (timer <= 0 || Input.GetKey(KeyCode.Space))
            {
                inicioFala1.SetActive(false);
                two = true;
                one=false;
                timer = tempo;
            }
        }

        if(two)
        {
            inicioFala2.SetActive(true);
            

            if (timer <= 0 || Input.GetKey(KeyCode.Space))
            {
                //inicioFala2.SetActive(false);
                two = false;
                timer = tempo;
            }

        } 
        if(!one && !two) LoadJ1();

        
    }

    public void LoadJ1()
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
    public void ControlsSelect()
    {
        activeScene = ActiveScene.CONTROLS;
    }
    public void ExitSelect()
    {
        activeScene = ActiveScene.EXIT;
    }
    public void PlaySelect()
    {
        timer=tempo;
        activeScene = ActiveScene.PLAY;
    }



}
