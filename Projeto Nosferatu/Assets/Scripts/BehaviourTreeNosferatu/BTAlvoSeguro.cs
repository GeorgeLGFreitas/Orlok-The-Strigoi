using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAlvoSeguro : BTNode
{
    public override IEnumerator Run(BehaviourTreeNosferatu bt) 
    {
        status = Status.FAILURE;
        GameObject alvo = GameObject.FindGameObjectWithTag("Player");
        
        
        if (alvo.GetComponent<Jogador>().seguro)
        {
            status = Status.SUCCESS;
        }
        Print(bt);
        yield break;                            
    }

}