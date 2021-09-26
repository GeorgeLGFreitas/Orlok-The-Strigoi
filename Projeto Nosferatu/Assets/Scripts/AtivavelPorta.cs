using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelPorta : Ativavel

{
    Jogador jogador;

   

    void Start()
    {
        jogador = FindObjectOfType<Jogador>();
    }

    void Update()
    {
        
    }
    
    public override void Ativar()
    {

        if(jogador.chave)
        {
            jogador.chave = false;
            Destroy(gameObject);
        
        }
    }
}
