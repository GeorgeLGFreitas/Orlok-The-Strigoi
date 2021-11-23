using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelRecargaTocha : Ativavel
{
    Stats stats;
    DialogueTrigger tochaReabastecerDialogo;

    private void Start()
    {
        stats = FindObjectOfType<Stats>();
        tochaReabastecerDialogo = GetComponent<DialogueTrigger>();
    }

    public override void Ativar()
    {
        stats.atualTocha = stats.maxTocha;
        tochaReabastecerDialogo.TriggerDialogue();
    }
}
