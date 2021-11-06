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

    bool abrePorta = false;
    float timer = 4.5f;

    public GameObject p1, p2;  // portas pra rotacionar
    GameObject porta;
    


    void Start()
    {
        jogador = FindObjectOfType<Jogador>();
    }

    void Update()
    {   
        if(abrePorta)
        {
            timer -= Time.deltaTime;
            
            gameObject.transform.Rotate(Vector3.up, Time.deltaTime * -25);
            if(timer <= 0)
            {
                timer = 4.5f;
                abrePorta = false;
            }
        }
    }
    
    public override void Ativar()
    {

        if(jogador.chave && porta1)
        {
            jogador.chave = false;
            jogador.porta = true;
            // -105 rotation Y

            abrePorta = true;            
            //Destroy(gameObject);
        
        }

        if(jogador.chave2 && porta2)
        {
            vitoria.gameObject.SetActive(true);
        
        }
    }

    IEnumerator AbrePorta()
    {   
        Debug.Log("abre porta");        
        
        gameObject.transform.Rotate(Vector3.up, Time.deltaTime * -25);       
        yield return new WaitForSeconds(4.5f);        
        
    }
}
