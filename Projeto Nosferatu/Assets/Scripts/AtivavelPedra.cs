using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelPedra : Ativavel
{
    Stats stats;
    QuestManager questManager;

    private void Start()
    {
        stats = FindObjectOfType<Stats>();
        questManager = FindObjectOfType<QuestManager>();
    }
    public override void Ativar()
    {
        questManager.interagiuPedra = true;

        stats.atualPedra++;
        stats.primeiraMira = true;

        Destroy(gameObject);
    }
}
