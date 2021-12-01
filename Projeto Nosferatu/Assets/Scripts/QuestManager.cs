using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    Jogador jogador;


    public Text text;

    [SerializeField]
    bool fase1;

    #region Fase 1 Booleans

    public bool firtsQuest = false;

    public bool bebeuVinho = false;

    public bool interagiuPorta = false;

    public bool interagiuPedra = false;

    public bool arremessou = false;

    public bool acharChave2 = false;

    #endregion

    #region Fase 2 Booleans

    public bool helpPrisioner = false;

    public bool helpedPrisioner = false;

    public bool vinhoEntregue = false;

    public bool acharDisco = false;

    public bool achouDisco = false;

    public bool discoPeloLivro = false;

    public bool naArea3 = false;

    public bool falta2Livros = false;

    public bool todosLivrosNaMesa = false;

    public bool subiuEscada = false;

    #endregion

    public string[] questsFase1;

    public string[] questsFase2;

    [SerializeField]
    DialogueTrigger dialogueTrigger;

    float timer = 1.75f;
    bool dialogueTriggerBool = false;
    void Start()
    {
        jogador = GetComponent<Jogador>();
        if (fase1)
        {
            text.text = questsFase1[5];
            firtsQuest = true;
        }
    }

    void Update()
    {
        if (fase1)
        {
            if (firtsQuest)
            {
                if (timer < Time.deltaTime)
                {
                    if (!dialogueTriggerBool)
                    {
                        dialogueTrigger.TriggerDialogue();
                        dialogueTriggerBool = true;

                        text.text = questsFase1[5] + "\n" + questsFase1[0];
                    }
                }
                timer -= Time.deltaTime;
                if (jogador.cantil)
                {
                    questsFase1[0] = "<color=red>Encontre o Cantil</color>";
                    text.text = questsFase1[5] + "\n" + questsFase1[0] + "\n" + questsFase1[1];

                    if (bebeuVinho)
                    {
                        questsFase1[1] = "<color=red>Mate sua sede</color>";
                        text.text = questsFase1[5] + "\n" + questsFase1[0] + "\n" + questsFase1[1];

                        if (jogador.porta)
                        {
                            questsFase1[2] = "<color=red>Abra a porta</color>";
                            text.text = questsFase1[5] + "\n" + questsFase1[0] + "\n" + questsFase1[1] + "\n" + questsFase1[2];

                            if (interagiuPedra)
                            {
                                text.text = questsFase1[5] + "\n" + questsFase1[0] + "\n" + questsFase1[1] + "\n" + questsFase1[2] + "\n" + questsFase1[3];

                                if (arremessou)
                                {
                                    questsFase1[3] = "<color=red>Arremesse</color>";
                                    text.text = questsFase1[5] + "\n" + questsFase1[0] + "\n" + questsFase1[1] + "\n" + questsFase1[2] + "\n" + questsFase1[3];

                                    if (acharChave2)
                                    {
                                        text.text = questsFase1[5] + "\n" + questsFase1[0] + "\n" + questsFase1[1] + "\n" + questsFase1[2] + "\n" + questsFase1[3] + "\n" + questsFase1[4];

                                        if (jogador.chave2)
                                        {
                                            questsFase1[4] = "<color=red>Encontre a chave</color>";
                                            text.text = questsFase1[5] + "\n" + questsFase1[0] + "\n" + questsFase1[1] + "\n" + questsFase1[2] + "\n" + questsFase1[3] + "\n" + questsFase1[4];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (helpPrisioner)
            {
                text.text = questsFase2[0];

                if (helpedPrisioner)
                {
                    questsFase2[0] = "<color=red>Ajude o Prisioneiro</color>";
                    text.text = questsFase2[0] + "\n" + questsFase2[1];

                    if (vinhoEntregue)
                    {
                        questsFase2[1] = "<color=red>Vinho para o Prisioneiro</color>";
                        text.text = questsFase2[0] + "\n" + questsFase2[1];

                        if (acharDisco)
                        {
                            text.text = questsFase2[0] + "\n" + questsFase2[1] + "\n" + questsFase2[2] + "\n" + questsFase2[3];

                            if (achouDisco)
                            {
                                questsFase2[2] = "<color=red>Encontre o Disco</color>";
                                text.text = questsFase2[0] + "\n" + questsFase2[1] + "\n" + questsFase2[2] + "\n" + questsFase2[3];

                                if (discoPeloLivro)
                                {
                                    questsFase2[3] = "<color=red>Disco pelo Livro</color>";
                                    text.text = questsFase2[0] + "\n" + questsFase2[1] + "\n" + questsFase2[2] + "\n" + questsFase2[3];

                                    if (naArea3)
                                    {
                                        //Missao 11
                                        text.text = questsFase2[4];

                                        if (falta2Livros)
                                        {
                                            text.text = questsFase2[4] + "\n" + questsFase2[5];

                                            if (todosLivrosNaMesa)
                                            {
                                                questsFase2[5] = "<color=red>Faltam dois.</color>";
                                                text.text = questsFase2[4] + "\n" + questsFase2[5];

                                                if (subiuEscada)
                                                {
                                                    questsFase2[4] = "<color=red>Fuja pelo teto.</color>";
                                                    text.text = questsFase2[4] + "\n" + questsFase2[5];
                                                    new WaitForSeconds(10);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }                        
                    }
                }
            }
        }
    }
}
