using System.Collections;
using UnityEngine;


public class BTMoverAteColetavel : BTNode
{
    public override IEnumerator Run(BehaviourTree bt) {
        {
            status = Status.RUNNING;
            Print(bt);

            GameObject[] objetos = GameObject.FindGameObjectsWithTag("Coletavel");
            GameObject alvo = null;
            float distancia = Mathf.Infinity;
            foreach (GameObject obj in objetos)
            {
                float dist = Vector3.Distance(bt.transform.position, obj.transform.position);
                if(dist < distancia)
                {
                    alvo = obj;
                    distancia = dist;
                }

                while (alvo)
                {
                    bt.transform.LookAt(alvo.transform);
                    bt.transform.Translate(Vector3.forward * 5 * Time.deltaTime);
                    
                    if (Vector3.Distance(bt.transform.position, alvo.transform.position) < 1)
                    {
                        status =Status.SUCCESS;
                        break;
                    }
                    yield return null;
                }

                if(status == Status.RUNNING) status = Status.FAILURE;
                Print(bt);
                               
            }
        }
    }
}