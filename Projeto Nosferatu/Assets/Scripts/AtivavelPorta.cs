using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class AtivavelPorta : Ativavel

{
    Jogador jogador;

    public AudioClip abre;
    public AudioSource audioS;
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

        if(porta1)
        {
            jogador.chave = false;
            jogador.porta = true;
            // -105 rotation Y

            abrePorta = true;
            audioS.PlayOneShot(abre);
            dialogueTrigger.TriggerDialogue();

            stats.numeroChave--;
        }

        if(porta2)
        {
            if (jogador.chave2)
            {
                if (jogador.cantil)
                {
                    SceneManager.LoadScene("Mapa 2");
                }
                else
                {
                    GetComponent<Selecionavel>().texto = "Cantil Necessario";
                }
            }
        }
        else
        {
            GetComponent<Selecionavel>().texto = "Trancado";
        }
    }

    IEnumerator AbrePorta()
    {   
        Debug.Log("abre porta");        
        
        gameObject.transform.Rotate(Vector3.up, Time.deltaTime * -25);       
        yield return new WaitForSeconds(4.5f);        
        
    }
}
