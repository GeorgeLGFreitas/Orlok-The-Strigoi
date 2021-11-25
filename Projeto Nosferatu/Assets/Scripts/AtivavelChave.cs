using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelChave : Ativavel
{
    Jogador jogador;
    mouseCursor cursor;
    Stats stats;
    public bool chave;
    public bool chave2;

    // Start is called before the first frame update
    void Start()
    {   
        jogador = FindObjectOfType<Jogador>();
        cursor = FindObjectOfType<mouseCursor>();
        stats = FindObjectOfType<Stats>();
     
    }


    public override void Ativar()
    {

        if(chave)
        {
            cursor.OriginalImage();
            jogador.chave = true;
            jogador.areaDeTexto.text = "";
            stats.numeroChave++;
            Destroy(gameObject);
        }

        if(chave2)
        {
            cursor.OriginalImage();
            jogador.chave2 = true;
            jogador.areaDeTexto.text = "";
            stats.numeroChave++;
            Destroy(gameObject);
        }
    }
}
