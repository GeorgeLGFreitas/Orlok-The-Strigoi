using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAlvoSeguro : BTNode
{
    public override IEnumerator Run(BehaviourTreeNosferatu bt) 
    {
        status = Status.FAILURE;
       ;
        
        
        if (bt.player.GetComponent<Jogador>().seguro)
        {
            status = Status.SUCCESS;
        }
        Print(bt);
        yield break;                            
    }

}