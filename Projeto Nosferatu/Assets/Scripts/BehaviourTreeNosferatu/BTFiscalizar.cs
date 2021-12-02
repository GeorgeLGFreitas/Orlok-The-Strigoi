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
        bt.Andando();
        
        if (Vector3.Distance(bt.transform.position, alvo.transform.position) < 0.5f)
        {
            bt.Correndo();
            bt.agente.SetDestination(bt.player.transform.position);
            status = Status.SUCCESS;
            //bt.agente.ResetPath();
            yield break;
        }

        else if (Vector3.Distance(bt.transform.position, alvo.transform.position) < 3)
        {
            bt.Idle();
            status = Status.SUCCESS;
            //bt.agente.ResetPath();
            
            yield break;
        }
        
      
        else if (status == Status.RUNNING) 
        {
            status = Status.FAILURE;

        }
        
        Print(bt);
        
    }

}