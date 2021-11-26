using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BTAlvoCampoDeVisao : BTNode
{
    public override IEnumerator Run(BehaviourTreeNosferatu bt)
    {

        status = Status.FAILURE;

        Ray raio = new Ray(bt.transform.position, bt.player.transform.position - bt.transform.position);
      

        if (Vector3.Angle(bt.transform.forward, raio.direction) < 90)
        {
            RaycastHit hit;
         
            if (Physics.Raycast(raio, out hit, 150))
            {
                if (hit.transform == bt.player.transform)
                {
                    status = Status.SUCCESS;
                }
            }
        }

        Print(bt);
        yield break;

    }


}
