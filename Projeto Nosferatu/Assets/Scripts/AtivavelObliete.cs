using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AtivavelObliete : Ativavel
{
    public string[] texto ;
    public Text textoC;
    

    float tempo = 0;

    void Start()
    {
        StartCoroutine(Dialogo());
    }
    public override void Ativar()
    {
        StartCoroutine(Dialogo());
        
    }

    public IEnumerator Dialogo()
    {
        textoC.text = texto[0];
        yield return new WaitForSeconds(5);
        textoC.text = "";
        
    }
    

    
    
}
