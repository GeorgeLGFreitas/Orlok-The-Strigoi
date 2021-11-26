using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelEscadaEndGame : Ativavel
{
    

    public override void Ativar()
    {
        FindObjectOfType<QuestManager>().subiuEscada = true;
    }
}
