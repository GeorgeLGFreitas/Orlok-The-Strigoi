using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelChave : Ativavel
{
    Jogador jogador;

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
        jogador.chave = true;
        Destroy(gameObject);
    }
}
