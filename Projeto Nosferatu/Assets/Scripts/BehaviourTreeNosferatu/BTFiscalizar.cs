using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTFiscalizar : BTNode
{
    public override IEnumerator Run(BehaviourTreeNosferatu bt)
    {

        status = Status.RUNNING;
        Print(bt);
        NavMeshAgent agente = GameObject.FindObjectOfType<NavMeshAgent>();
        GameObject alvo = GameObject.FindGameObjectWithTag("Atencao");

        agente.SetDestination(alvo.transform.position);
        if (Vector3.Distance(bt.transform.position, alvo.transform.position) < 5)
        {
            status = Status.SUCCESS;
            yield break;

        }

        else if (status == Status.RUNNING) status = Status.FAILURE;
        Print(bt);
        
    }

}