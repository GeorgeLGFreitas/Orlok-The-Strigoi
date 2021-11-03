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
    GameObject porta;
   

    void Start()
    {
        jogador = FindObjectOfType<Jogador>();
    }

    void Update()
    {
        //p1.transform.Rotate(Vector3.up, Time.deltaTime * -25);
    }
    
    public override void Ativar()
    {

        if(jogador.chave && porta1)
        {
            jogador.chave = false;
            jogador.porta = true;
            // -105 rotation Y

            porta = p1;
            StartCoroutine(AbrePorta());
            //p1.transform.Rotate(0, -105 , 0);
            Destroy(gameObject);
        
        }

        if(jogador.chave2 && porta2)
        {
            vitoria.gameObject.SetActive(true);
        
        }
    }

    IEnumerator AbrePorta()
    {   
        //Debug.Log("abre porta");        
        
        gameObject.transform.Rotate(Vector3.up, Time.deltaTime * -25);       
        yield return new WaitForSeconds(4.5f);
        
        
    }
}
