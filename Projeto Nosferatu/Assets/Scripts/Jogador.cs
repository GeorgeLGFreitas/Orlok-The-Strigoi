using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jogador : MonoBehaviour
{
    Selecionavel selecionado;
    public GameObject tochaGO;
    public Text areaDeTexto;
    public bool chave;
    public bool chave2;
    public bool tocha;
    public bool porta;

    // Start is called before the first frame update
    void Start()
    {
        chave = false;
        tocha = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        Ray raio = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        Debug.DrawRay(raio.origin, Camera.main.transform.forward * 50, Color.cyan);
        
        Selecionavel novaSelecao = null;

        if(Physics.Raycast(raio, out hit, 3.5f))
        {
           novaSelecao = hit.transform.GetComponent<Selecionavel>();
        }
        
        if(selecionado)
        {
            selecionado.Desliga();
            areaDeTexto.text = "";
            selecionado = null;
        }

        if(novaSelecao)
        {
            novaSelecao.Liga();
            areaDeTexto.text = novaSelecao.texto;
            selecionado = novaSelecao;

            Ativavel atual = novaSelecao.GetComponent<Ativavel>();
            if(atual)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    atual.Ativar();             
                }
            }
        }
        else{areaDeTexto.text = "";}

        if(tocha == true)
        {
            tochaGO.SetActive(true);
        }
        else tochaGO.SetActive(false);
    }
 
    
    
}