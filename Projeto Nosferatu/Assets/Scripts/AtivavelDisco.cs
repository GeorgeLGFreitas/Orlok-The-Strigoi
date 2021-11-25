using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelDisco : Ativavel
{
    QuestManager questManager;
    mouseCursor cursor;
    Stats stats;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        cursor = FindObjectOfType<mouseCursor>();
        stats = FindObjectOfType<Stats>();
    }

    public override void Ativar()
    {
        questManager.achouDisco = true;
        cursor.OriginalImage();
        stats.numeroDiscoPrato++;
        Destroy(gameObject);
    }
}
