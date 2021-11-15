using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelDialogo : Ativavel
{
    public override void Ativar()
    {
        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}
