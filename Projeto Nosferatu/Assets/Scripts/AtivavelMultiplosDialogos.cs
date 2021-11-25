using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelMultiplosDialogos : Ativavel
{
    [SerializeField]
    DialogueTrigger primeiroDialogo;
    [SerializeField]
    DialogueTrigger segundoDialogo;
    [SerializeField]
    DialogueTrigger terceiroDialogo;
    [SerializeField]
    DialogueTrigger itemErradoDialogo;

    [SerializeField]
    GameObject triggerCutscene;

    bool primeiroDialogoTrigged;
    bool segundoDialogoTrigged;
    bool terceiroDialogoTrigged;

    QuestManager questManager;
    Stats stats;

    private void Start()
    {
        primeiroDialogoTrigged = false;
        segundoDialogoTrigged = false;
        terceiroDialogoTrigged = false;

        triggerCutscene.SetActive(false);

        questManager = FindObjectOfType<QuestManager>();
        stats = FindObjectOfType<Stats>();
    }

    public override void Ativar()
    {
        if (!primeiroDialogoTrigged)
        {
            if (stats.itemsGroupBool[5] == true & stats.numeroAlimento != 0)
            {
                primeiroDialogo.TriggerDialogue();
                primeiroDialogoTrigged = true;
                questManager.helpPrisioner = true;
            }
            else
            {
                itemErradoDialogo.TriggerDialogue();
            }
        }
        else
        {
            if (!segundoDialogoTrigged)
            {
                if (stats.itemsGroupBool[1] == true)
                {
                    segundoDialogo.TriggerDialogue();
                    segundoDialogoTrigged = true;
                    questManager.helpedPrisioner = true;
                }
                else
                {
                    itemErradoDialogo.TriggerDialogue();
                }
            }
            else
            {
                if (!terceiroDialogoTrigged)
                {
                    if (stats.atualCantil != 0)
                    {
                        stats.atualCantil = 0;
                        terceiroDialogo.TriggerDialogue();
                        terceiroDialogoTrigged = true;

                        FindObjectOfType<DialogueManager>().triggerQuest = true;

                        triggerCutscene.SetActive(true);
                    }
                    else
                    {
                        itemErradoDialogo.TriggerDialogue();
                    }
                }
            }
        }
    }
}
