using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelVinho : Ativavel
{
    public override void Ativar()
    {
        FindObjectOfType<Stats>().atualCantil = FindObjectOfType<Stats>().maxCantil;
        GetComponent<mouseCursor>().OriginalImage();
        FindObjectOfType<Stats>().textoC.text = "";
        Destroy(gameObject);
    }
}
