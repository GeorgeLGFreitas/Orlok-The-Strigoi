using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NosferatuAI : MonoBehaviour
{
    public GameObject alvo;
    void Start()
    {
        
        BTSequence persegue = new BTSequence();
        persegue.children.Add(new BTAlvoProximo());
        persegue.children.Add(new BTAlvoCampoDeVisao());
        persegue.children.Add(new BTAlvoSeguro());
        persegue.children.Add(new BTPerseguirAlvo());

      
        BTSelector selecao = new BTSelector();
        selecao.children.Add(persegue);


        BehaviourTreeNosferatu bt = GetComponent<BehaviourTreeNosferatu>();
        bt.root = selecao;

        StartCoroutine(bt.Begin());
    }
}