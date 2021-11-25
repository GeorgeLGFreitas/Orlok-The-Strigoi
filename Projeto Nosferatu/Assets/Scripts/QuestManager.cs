using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    Jogador jogador;


    public Text text;

    public bool firtsQuest = false;

    public bool bebeuVinho = false;

    public bool interagiuPorta = false;

    public bool interagiuPedra = false;

    public bool arremessou = false;

    public string[] quests;

    [SerializeField]
    DialogueTrigger dialogueTrigger;

    float timer = 1.75f;
    bool dialogueTriggerBool = false;
    void Start()
    {
        jogador = GetComponent<Jogador>();
        text.text = quests[7];
    }

    void Update()
    {
        if (firtsQuest)
        {
            text.text = quests[7] + "\n" + quests[0];

            if (timer < Time.deltaTime)
            {
                if (!dialogueTriggerBool)
                {
                    dialogueTrigger.TriggerDialogue();
                    dialogueTriggerBool = true;
                }
            }
            timer -= Time.deltaTime;
            if (jogador.cantil)
            {
                quests[0] = "<color=red>Encontre o Cantil</color>";
                text.text = quests[7] + "\n" + quests[0] + "\n" + quests[1];

                if (bebeuVinho)
                {
                    quests[1] = "<color=red>Mate sua sede</color>";
                    text.text = quests[7] + "\n" + quests[0] + "\n" + quests[1];

                    if (interagiuPorta)
                    {
                        text.text = quests[7] + "\n" + quests[0] + "\n" + quests[1] + "\n" + quests[2];
                    }

                    if (jogador.chave)
                    {
                        quests[2] = "<color=red>Encontre a chave</color>";
                        text.text = quests[7] + "\n" + quests[0] + "\n" + quests[1] + "\n" + quests[2] + "\n" + quests[3];
                    }
                    else
                    {
                        if (jogador.porta)
                        {
                            quests[3] = "<color=red>Abra a porta</color>";
                            text.text = quests[7] + "\n" + quests[0] + "\n" + quests[1] + "\n" + quests[2] + "\n" + quests[3];

                            if (interagiuPedra)
                            {
                                text.text = quests[7] + "\n" + quests[0] + "\n" + quests[1] + "\n" + quests[2] + "\n" + quests[3] + "\n" + quests[4];

                                if (arremessou)
                                {
                                    quests[4] = "<color=red>Arremesse</color>";
                                    text.text = quests[7] + "\n" + quests[0] + "\n" + quests[1] + "\n" + quests[2] + "\n" + quests[3] + "\n" + quests[4];
                                }
                            }

                            if (jogador.chave2)
                            {
                                quests[5] = "<color=red>Ache a segunda chave</color>";
                                text.text = quests[7] + "\n" + quests[0] + "\n" + quests[1] + "\n" + quests[2] + "\n" + quests[3] + "\n" + quests[4] + "\n" + quests[5];
                            }
                        }
                    }
                }
            }
        }
    }
}
