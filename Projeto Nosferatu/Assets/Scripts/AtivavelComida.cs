using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelComida : Ativavel
{
    public override void Ativar()
    {
        FindObjectOfType<mouseCursor>().OriginalImage();
        FindObjectOfType<Stats>().numeroAlimento++;
        FindObjectOfType<Jogador>().areaDeTexto.text = "";
        Destroy(gameObject);
    }
}
