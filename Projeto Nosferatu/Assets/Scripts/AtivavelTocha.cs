using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelTocha : Ativavel
{
    
    Jogador jogador;
    public GameObject tocha;

    

    void Start()
    {
        jogador = FindObjectOfType<Jogador>();
    }

    public override void Ativar()
    {
        jogador.tocha = true;
        Destroy(tocha);

    }
}
