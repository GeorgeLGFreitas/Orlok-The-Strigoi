using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BTAlvoProximo : BTNode
{
    public override IEnumerator Run(BehaviourTreeNosferatu bt) 
    {
        status = Status.FAILURE;
        GameObject alvo = GameObject.FindGameObjectWithTag("Player");
        
        if (Vector3.Distance(bt.transform.position, alvo.transform.position) < 20)
        {
            status = Status.SUCCESS;
            
        }
        
        Print(bt);
        yield break;
                               
    }
}