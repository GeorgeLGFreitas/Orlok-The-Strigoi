using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NosferatuAI : MonoBehaviour
{
    public GameObject alvo;
    void Start()
    {
        BTInversor naoAlvoProximo = new BTInversor();
        naoAlvoProximo.child = new BTAlvoProximo();

        BTInversor naoTemBarulho = new BTInversor();
        naoTemBarulho.child = new BTTemBarulho();

        BTInversor naoCampoDeVisao = new BTInversor();
        naoCampoDeVisao.child = new BTAlvoCampoDeVisao();
        
        BTSequence persegue = new BTSequence();
        persegue.children.Add(new BTAlvoCampoDeVisao());
        persegue.children.Add(new BTAlvoSeguro());
        persegue.children.Add(new BTPerseguirAlvo());

        BTSequence perseguePerto = new BTSequence();
        perseguePerto.children.Add(new BTAlvoProximo());
        perseguePerto.children.Add(new BTTemBarulho());
        perseguePerto.children.Add(new BTPerseguirAlvo());

        BTSequence vagar = new BTSequence();
        vagar.children.Add(naoAlvoProximo);
        vagar.children.Add(naoTemBarulho);
        //vagar.children.Add(new BTPerseguirAlvo());

        BTSequence fiscalizar = new BTSequence();
        fiscalizar.children.Add(new BTTemBarulho());
        fiscalizar.children.Add(new BTFiscalizar());



        BTSelector selecao = new BTSelector();
        selecao.children.Add(persegue);
        selecao.children.Add(perseguePerto);
        selecao.children.Add(fiscalizar);
        //selecao.children.Add(vagar);

        BehaviourTreeNosferatu bt = GetComponent<BehaviourTreeNosferatu>();
        bt.root = selecao;

        StartCoroutine(bt.Begin());
    }
}