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

        BTInversor naoSeguro = new BTInversor();
        naoSeguro.child = new BTAlvoSeguro();
        
        BTSequence persegue = new BTSequence();
        persegue.children.Add(naoSeguro);
        //persegue.children.Add(new BTAlvoProximo());
        persegue.children.Add(new BTAlvoCampoDeVisao());
        persegue.children.Add(new BTPerseguirAlvo());

        BTSequence perseguePerto = new BTSequence();
        perseguePerto.children.Add(new BTAlvoProximo());
        perseguePerto.children.Add(naoCampoDeVisao);
        perseguePerto.children.Add(new BTTemBarulho());
        perseguePerto.children.Add(new BTPerseguirAlvo());

        BTSequence fiscalizar = new BTSequence();
        fiscalizar.children.Add(new BTTemBarulho());
        fiscalizar.children.Add(naoCampoDeVisao);
        fiscalizar.children.Add(new BTFiscalizar());

        BTSequence vagar = new BTSequence();
        vagar.children.Add(naoAlvoProximo);
        vagar.children.Add(naoTemBarulho);
        //vagar.children.Add(new BTPerseguirAlvo());

        BTSelector selecao = new BTSelector();
        selecao.children.Add(persegue);
        selecao.children.Add(fiscalizar);
        //selecao.children.Add(perseguePerto);
        //selecao.children.Add(vagar);

        BehaviourTreeNosferatu bt = GetComponent<BehaviourTreeNosferatu>();
        bt.root = selecao;

        StartCoroutine(bt.Begin());
    }
}