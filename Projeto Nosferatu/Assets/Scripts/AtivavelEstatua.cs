using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelEstatua : Ativavel
{
    [SerializeField]
    GameObject livroIGameObject;
    [SerializeField]
    GameObject discoGameObject;
    [SerializeField]
    AtivavelPortaSemChave portaSemChave;

    QuestManager questManager;
    mouseCursor cursor;
    Stats stats;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
        cursor = FindObjectOfType<mouseCursor>();
        stats = FindObjectOfType<Stats>();

        livroIGameObject.SetActive(true);
        discoGameObject.SetActive(false);
        portaSemChave.enabled = false;
    }

    public override void Ativar()
    {
        if (stats.numeroDiscoPrato != 0)
        {
            stats.numeroDiscoPrato--;
            discoGameObject.SetActive(true);

            stats.numeroLivroI++;
            livroIGameObject.SetActive(false);

            questManager.discoPeloLivro = true;

            portaSemChave.enabled = true;
        }
    }
}
