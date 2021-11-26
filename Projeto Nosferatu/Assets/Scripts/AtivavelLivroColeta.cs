using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelLivroColeta : Ativavel
{
    [SerializeField]
    bool isLivroIII;

    Stats stats;
    mouseCursor cursor;
    DialogueTrigger dialogue;

    private void Start()
    {
        stats = FindObjectOfType<Stats>();
        cursor = GetComponent<mouseCursor>();
        dialogue = GetComponent<DialogueTrigger>();
    }

    public override void Ativar()
    {
        if (isLivroIII)
        {
            cursor.OriginalImage();
            //dialogue.TriggerDialogue();
            stats.numeroLivroIII++;
            Destroy(gameObject);
        }
        else
        {
            cursor.OriginalImage();
            stats.numeroLivroXIII++;
            Destroy(gameObject);
        }
    }
}
