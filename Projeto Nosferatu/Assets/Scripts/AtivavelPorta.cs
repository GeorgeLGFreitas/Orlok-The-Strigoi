using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class AtivavelPorta : Ativavel

{
    Jogador jogador;
    public RawImage vitoria;
    public bool porta1;
    public bool porta2;

    bool abrePorta = false;
    float timer = 4.5f;

    public GameObject p1, p2;  // portas pra rotacionar
    GameObject porta;

    [SerializeField]
    QuestManager questManager;
    DialogueTrigger dialogueTrigger;

    Stats stats;

    void Start()
    {
        jogador = FindObjectOfType<Jogador>();
        dialogueTrigger = GetComponent<DialogueTrigger>();
        stats = FindObjectOfType<Stats>();
    }

    void Update()
    {   
        if(abrePorta)
        {
            timer -= Time.deltaTime;
            
            gameObject.transform.Rotate(Vector3.up, Time.deltaTime * -25);
            if(timer <= 0)
            {
                timer = 4.5f;
                abrePorta = false;
            }
        }
    }
    
    public override void Ativar()
    {

        if(jogador.chave && porta1)
        {
            jogador.chave = false;
            jogador.porta = true;
            // -105 rotation Y

            abrePorta = true;

            dialogueTrigger.TriggerDialogue();

            stats.numeroChave--;
        }
        else
        {
            questManager.interagiuPorta = true;
        }

        if(jogador.chave2 && porta2)
        {
            SceneManager.LoadScene("Mapa 2");
        
        }
    }

    IEnumerator AbrePorta()
    {   
        Debug.Log("abre porta");        
        
        gameObject.transform.Rotate(Vector3.up, Time.deltaTime * -25);       
        yield return new WaitForSeconds(4.5f);        
        
    }
}
