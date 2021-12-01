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

    [SerializeField]
    BalancaRodar balanca;

    int vezesAtivado;

    private void Start()
    {
        stats = FindObjectOfType<Stats>();
    }

    public override void Ativar()
    {
        if(paredeAnimator.GetBool("isParedeOpen") == false)
        {
            if (stats.atualCantil < vinhoNecessario)
            {
                 
                balanca.quantidade = 100 * stats.atualCantil / 150;
                Debug.Log(balanca.quantidade);
                balanca.RodaBalanca1();
                vinhoNecessario -= stats.atualCantil;
                stats.atualCantil = 0;
            }
            else
            {
                balanca.quantidade = 100 * stats.atualCantil / 150;
                Debug.Log(balanca.quantidade);
                stats.atualCantil -= vinhoNecessario;
                balanca.RodaBalanca1();
                paredeAnimator.SetBool("isParedeOpen", true);
            }
        }
    }
}
