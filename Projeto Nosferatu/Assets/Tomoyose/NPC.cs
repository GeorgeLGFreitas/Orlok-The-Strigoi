using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    void Start()
    {
        BTSequence coleta = new BTSequence();
        coleta.children.Add(new BTTemColetavel());
        coleta.children.Add(new BTMoverAteColetavel());
        coleta.children.Add(new BTPegarColetavel());

        BehaviourTree bt = GetComponent<BehaviourTree>();
        bt.root = coleta;

        StartCoroutine(bt.Begin());

    }
}