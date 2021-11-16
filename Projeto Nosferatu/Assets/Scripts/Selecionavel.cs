using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecionavel : MonoBehaviour
{
    public Color corPadrao = Color.black;
    public Color corSelecionado = Color.yellow * 0.6f;

    public string texto = "Click"; 

    MeshRenderer render;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
        render.material.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        
    }

    public void Liga()
    {
        render.material.SetColor("_EmissionColor", corSelecionado);
    }

     public void Desliga()
    {
        render.material.SetColor("_EmissionColor", corPadrao);
    }
}
