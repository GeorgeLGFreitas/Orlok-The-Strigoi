using System.Collections;
using UnityEngine;

public class BTTemColetavel : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        GameObject encontrou = GameObject.FindWithTag("Coletavel");
        if (encontrou) status = Status.SUCCESS;
        else status = Status.FAILURE;
        yield break;
    }
}