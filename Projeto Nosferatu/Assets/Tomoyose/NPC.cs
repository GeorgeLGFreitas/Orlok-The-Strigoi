using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject alvo;
    void Start()
    {
        BTSequence coleta = new BTSequence();
        coleta.children.Add(new BTTemColetavel());
        coleta.children.Add(new BTMoverAteColetavel());
        coleta.children.Add(new BTPegarColetavel());

        BTSequence combate = new BTSequence();
        combate.children.Add(new BTOponenteProximo());

        BTSelector selecao = new BTSelector();
        selecao.children.Add(combate);
        selecao.children.Add(coleta);


        BehaviourTree bt = GetComponent<BehaviourTree>();
        bt.root = selecao;

        StartCoroutine(bt.Begin());

    }
}