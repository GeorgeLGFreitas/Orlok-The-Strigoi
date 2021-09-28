using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    Jogador jogador;
    public Text text;
    public Image tutorialJ1;
    bool tutorial = true;

    public string[] quests;

   
    void Start()
    {
        //tutorialJ1 = GetComponent<Image>();
        jogador = GetComponent<Jogador>();
        text.text = quests[0];
        
        //if(tutorial == false) ;


    }
    void Awake() 
    {
        StartCoroutine(tempoTutorial());
    }

    void Update()
    {
        if(jogador.tocha)
        {
            text.text = quests[1];
        }

        if(jogador.chave)
        {
            text.text = quests[2];
        }

        if(jogador.porta)
        {
            text.text = quests[3];
        }

        if(jogador.chave2)
        {
            text.text = quests[4];
            
        }

        




        
    }
    public IEnumerator tempoTutorial()
    {
        yield return new WaitForSeconds(10);
        Destroy(tutorialJ1.gameObject);
        
        yield return null;
            
    }
}
