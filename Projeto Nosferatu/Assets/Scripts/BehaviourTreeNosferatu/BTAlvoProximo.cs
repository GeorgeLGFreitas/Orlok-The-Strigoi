using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BTAlvoProximo : BTNode
{
    public override IEnumerator Run(BehaviourTreeNosferatu bt) 
    {
        status = Status.FAILURE;
        
        if (Vector3.Distance(bt.transform.position, bt.player.transform.position) < 10)
        {
            status = Status.SUCCESS;
            
        }
        
        Print(bt);
        yield break;
                               
    }
}