using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelRecargaTocha : Ativavel
{
    Stats stats;
    Jogador jogador;
    [SerializeField]
    AudioClip somRecarregaTocha;
    DialogueTrigger tochaReabastecerDialogo;
    public GameObject tocha;

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
            GetComponent<AudioSource>().PlayOneShot(somRecarregaTocha);
        }
        else
        {
            jogador.tocha = true;
            stats.atualTocha = stats.maxTocha;
            Destroy(tocha);
        }
    }
}
