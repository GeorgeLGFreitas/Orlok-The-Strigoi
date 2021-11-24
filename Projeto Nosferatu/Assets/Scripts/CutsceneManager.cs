using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    Jogador jogador;
    Movimento movimento;

    Animator animator;

    Camera cutsceneCamera;
    Camera jogadorCamera;

    private void Start()
    {
        jogador = FindObjectOfType<Jogador>();
        movimento = FindObjectOfType<Movimento>();
    }
}
