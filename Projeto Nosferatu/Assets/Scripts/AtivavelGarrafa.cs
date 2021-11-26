using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelGarrafa : Ativavel
{
    public override void Ativar()
    {
        FindObjectOfType<Stats>().atualGarrafa++;
        GetComponent<mouseCursor>().OriginalImage();
        Destroy(gameObject);
    }
}
