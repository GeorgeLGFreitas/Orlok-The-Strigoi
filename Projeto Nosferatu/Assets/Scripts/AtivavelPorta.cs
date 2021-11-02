using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AtivavelPorta : Ativavel

{
    Jogador jogador;
    public RawImage vitoria;
    public bool porta1;
    public bool porta2;

    public GameObject p1, p2;  // portas pra rotacionar
   

    void Start()
    {
        jogador = FindObjectOfType<Jogador>();
    }

    void Update()
    {
        
    }
    
    public override void Ativar()
    {

        if(jogador.chave && porta1)
        {
            jogador.chave = false;
            jogador.porta = true;
            // -105 rotation Y

            p1.transform.Rotate(0, -52 , 0);
            //Destroy(gameObject);
        
        }

        if(jogador.chave2 && porta2)
        {
            vitoria.gameObject.SetActive(true);
        
        }
    }
}
