using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelRecargaTocha : Ativavel
{
    Stats stats;
    Jogador jogador;
    DialogueTrigger tochaReabastecerDialogo;
    public GameObject tocha;
    [SerializeField]
    AudioClip somTochaRecarregar;

    private void Start()
    {
        stats = FindObjectOfType<Stats>();
        jogador = FindObjectOfType<Jogador>();
        tochaReabastecerDialogo = GetComponent<DialogueTrigger>();
    }

    public override void Ativar()
    {
        if (jogador.tocha)
        {
            stats.atualTocha = stats.maxTocha;
            tochaReabastecerDialogo.TriggerDialogue();
            GetComponent<AudioSource>().PlayOneShot(somTochaRecarregar);
        }
        else
        {
            jogador.tocha = true;
            stats.atualTocha = stats.maxTocha;
            Destroy(tocha);
        }
    }
}
