using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelChave : Ativavel
{
    Jogador jogador;
    mouseCursor cursor;

    public bool chave;
    public bool chave2;

    // Start is called before the first frame update
    void Start()
    {   
        jogador = FindObjectOfType<Jogador>();
        cursor = FindObjectOfType<mouseCursor>();
    }


    public override void Ativar()
    {
        if(chave)
        {
            //cursor.coletar = true;
            jogador.chave = true;
            Destroy(gameObject);
        }

        if(chave2)
        {
            //cursor.coletar = true;
            jogador.chave2 = true;
            Destroy(gameObject);
        }
    }
}
