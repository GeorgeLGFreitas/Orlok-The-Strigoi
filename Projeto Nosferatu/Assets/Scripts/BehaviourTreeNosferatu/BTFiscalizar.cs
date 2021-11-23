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
        
        GameObject alvo = GameObject.FindGameObjectWithTag("Atencao");

        bt.agente.SetDestination(alvo.transform.position);
        if (Vector3.Distance(bt.transform.position, alvo.transform.position) < 2)
        {
            bt.agente.ResetPath();
            status = Status.SUCCESS;
            yield break;

        }
      
        else if (status == Status.RUNNING) status = Status.FAILURE;
        Print(bt);
        
    }

}