using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivavelQuestCantilFase2 : Ativavel
{
    [SerializeField]
    Animator paredeAnimator;
    Stats stats;

    [SerializeField]
    float vinhoNecessario;

    private void Start()
    {
        stats = FindObjectOfType<Stats>();
    }

    public override void Ativar()
    {
        if (stats.atualCantil < vinhoNecessario)
        {

        }
        else
        {
            stats.atualCantil -= vinhoNecessario;

            paredeAnimator.SetBool("isParedeOpen", true);
        }
    }
}
