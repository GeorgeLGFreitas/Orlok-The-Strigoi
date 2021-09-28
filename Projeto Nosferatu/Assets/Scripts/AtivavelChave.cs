using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelChave : Ativavel
{
    Jogador jogador;

    public bool chave;
    public bool chave2;

    // Start is called before the first frame update
    void Start()
    {   
        jogador = FindObjectOfType<Jogador>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Ativar()
    {
        if(chave)
        {
            jogador.chave = true;
            Destroy(gameObject);
        }

        if(chave2)
        {
            jogador.chave2 = true;
            Destroy(gameObject);
        }
    }
}
