using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelEscadaEndGame : Ativavel
{
    bool trigged = false;

    public override void Ativar()
    {
        trigged = true;
    }

    private void Update()
    {
        if (trigged)
        {
            FindObjectOfType<QuestManager>().subiuEscada = true;
            FindObjectOfType<DialogoCinemaMudo>().FalasFinal();
        }
    }
}
