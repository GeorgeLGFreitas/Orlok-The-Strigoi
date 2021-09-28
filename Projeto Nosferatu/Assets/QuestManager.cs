using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    Jogador jogador;
    public Text text;

    public string[] quests;

   
    void Start()
    {
        jogador = GetComponent<Jogador>();
        text.text = quests[0];
    }

    void Update()
    {

        if(jogador.chave)
        {
            text.text = quests[1];
        }

        if(jogador.porta)
        {
            text.text = quests[2];
        }

        if(jogador.chave2)
        {
            text.text = quests[3];
            
        }
        
    }
}
