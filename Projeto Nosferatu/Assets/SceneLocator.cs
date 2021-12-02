using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLocator : MonoBehaviour
{
    public int cenaF = 0;
    public int cenaC = 0;
    Scene cena;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        cena = SceneManager.GetActiveScene();
        cenaC = cena.buildIndex;
        if(cenaC != 3) cenaF = cena.buildIndex;
    }
}
