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
        
        BTSequence persegue = new BTSequence();
        //persegue.children.Add(new BTAlvoProximo());
        persegue.children.Add(new BTAlvoCampoDeVisao());
        persegue.children.Add(new BTAlvoSeguro());
        persegue.children.Add(new BTPerseguirAlvo());

        BTSequence vagar = new BTSequence();
        vagar.children.Add(naoAlvoProximo);
        vagar.children.Add(new BTPerseguirAlvo());

        BTSelector selecao = new BTSelector();
        selecao.children.Add(persegue);
        //selecao.children.Add(vagar);

        BehaviourTreeNosferatu bt = GetComponent<BehaviourTreeNosferatu>();
        bt.root = selecao;

        StartCoroutine(bt.Begin());
    }
}