using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BTAlvoCampoDeVisao : BTNode
{
    public override IEnumerator Run(BehaviourTreeNosferatu bt)
    {

        status = Status.FAILURE;

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");


        Ray raio = new Ray(bt.transform.position, alvo.transform.position - bt.transform.position);
        

        if (Vector3.Angle(bt.transform.forward, raio.direction) < 50)
        {
            RaycastHit hit;
            Debug.Log("aa");

            if (Physics.Raycast(raio, out hit, 50))
            {

                if (hit.transform == alvo.transform)
                {

                    status = Status.SUCCESS;

                }
            }
        }

        Print(bt);
        yield break;

    }


}
