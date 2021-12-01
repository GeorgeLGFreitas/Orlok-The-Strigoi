using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecionavel : MonoBehaviour
{
    public Color corPadrao = Color.black;
    public Color corSelecionado = Color.yellow * 0.6f;

    public string texto = "Click"; 

    MeshRenderer render;

    public mouseCursor mouseCursor;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
        render.material.EnableKeyword("_EMISSION");
        mouseCursor = GetComponent<mouseCursor>();
    }

    public void Liga()
    {
        render.material.SetColor("_EmissionColor", corSelecionado);
        mouseCursor.ChangeImage();

        AtivavelPorta porta = GetComponent<AtivavelPorta>();
        if (porta != null)
        {
            if (porta.porta2 & FindObjectOfType<Jogador>().chave2 == false)
            {
                texto = "Trancado";
            }
            else
            {
                texto = "E ou Clique";
            }
        }
    }

     public void Desliga()
    {
        render.material.SetColor("_EmissionColor", corPadrao);
        mouseCursor.OriginalImage();
    }
}
