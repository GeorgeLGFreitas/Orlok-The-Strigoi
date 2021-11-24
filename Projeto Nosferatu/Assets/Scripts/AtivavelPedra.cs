using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelPedra : Ativavel
{
    Stats stats;
    mouseCursor cursor;
    QuestManager questManager;

    private void Start()
    {
        stats = FindObjectOfType<Stats>();
        cursor = GetComponent<mouseCursor>();
        questManager = FindObjectOfType<QuestManager>();
    }
    public override void Ativar()
    {
        questManager.interagiuPedra = true;

        stats.atualPedra++;
        stats.primeiraMira = true;

        cursor.OriginalImage();

        Destroy(gameObject);
    }
}
