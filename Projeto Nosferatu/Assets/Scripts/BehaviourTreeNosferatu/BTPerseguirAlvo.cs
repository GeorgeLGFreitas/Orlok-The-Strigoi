using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class BTPerseguirAlvo : BTNode
{
    public override IEnumerator Run(BehaviourTreeNosferatu bt)
    {

        status = Status.RUNNING;
        Print(bt);
        
       
        bt.agente.SetDestination(bt.player.transform.position);
        
        
        bt.Correndo();
        if (Vector3.Distance(bt.transform.position, bt.player.transform.position) < 1)
        {
            status = Status.SUCCESS;
            bt.Idle();
            SceneManager.LoadScene("GameOver");
            
            yield break;

        }

        else if (status == Status.RUNNING) status = Status.FAILURE;
        //bt.Idle();
        Print(bt);
        
    }  

}