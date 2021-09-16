using System.Collections;
using System.Collections.Generic;
public class BTOponenteProximo : BTNode
{
    public override IEnumerator Run(BehaviourTree bt) 
    {
        status = Status.FAILURE;
        GameObject[] oponentes = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject oponente in oponentes)
        {
            if(oponente == bt.gameObject)continue;
            if (Vector3.Distance(bt.transform.position, oponente.transform.position) < 10)
            status = Status.SUCCESS;
            break;
        }
        
        Print(bt);
        yield break;
                               
    }
}