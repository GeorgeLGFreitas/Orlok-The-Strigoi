using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelLivro : Ativavel
{
    QuestManager questManager;

    Stats stats;

    public bool livroIEstaColocado;
    public bool livroIIIEstaColocado;
    public bool livroXIIIEstaColocado;

    [SerializeField]
    GameObject livroI;
    [SerializeField]
    GameObject livroIII;
    [SerializeField]
    GameObject livroXIII;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();

        stats = FindObjectOfType<Stats>();
    }

    private void Update()
    {
        if (livroIEstaColocado)
        {
            livroI.SetActive(true);
        }
        else
        {
            livroI.SetActive(false);
        }

        if (livroIIIEstaColocado)
        {
            livroIII.SetActive(true);
        }
        else
        {
            livroIII.SetActive(false);
        }
        
        if (livroXIIIEstaColocado)
        {
            livroXIII.SetActive(true);
        }
        else
        {
            livroXIII.SetActive(false);
        }
    }

    public override void Ativar()
    {
        if (livroIEstaColocado)
        {
            stats.numeroLivroI++;
            livroIEstaColocado = false;
        }
        else
        {
            if (stats.numeroLivroI != 0 & stats.itemsGroupBool[2] == true)
            {
                if (questManager.falta2Livros == false)
                {
                    questManager.falta2Livros = true;

                    //GetComponent<DialogueTrigger>().TriggerDialogue();
                }

                stats.numeroLivroI--;
                livroIEstaColocado = true;
            }
        }

        if (livroIIIEstaColocado)
        {
            stats.numeroLivroIII++;
            livroIIIEstaColocado = false;
        }
        else
        {
            if (stats.numeroLivroIII != 0 & stats.itemsGroupBool[3] == true)
            {
                if (questManager.falta2Livros == false)
                {
                    questManager.falta2Livros = true;

                    GetComponent<DialogueTrigger>().TriggerDialogue();
                }

                stats.numeroLivroIII--;
                livroIIIEstaColocado = true;
            }
        }
        
        if (livroXIIIEstaColocado)
        {
            stats.numeroLivroXIII++;
            livroXIIIEstaColocado = false;
        }
        else
        {
            if (stats.numeroLivroXIII != 0 & stats.itemsGroupBool[4] == true)
            {
                if (questManager.falta2Livros == false)
                {
                    questManager.falta2Livros = true;

                    GetComponent<DialogueTrigger>().TriggerDialogue();
                }

                stats.numeroLivroXIII--;
                livroXIIIEstaColocado = true;
            }
        }
    }
}
