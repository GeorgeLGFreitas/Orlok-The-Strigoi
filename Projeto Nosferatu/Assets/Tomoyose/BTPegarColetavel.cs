using System.Collections;
using UnityEngine;

public class BTPegarColetavel : BTNode
{
    public override IEnumerator Run(BehaviourTree bt)
    {
        status = Status.FAILURE;
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("Coletavel");
        foreach (GameObject obj in objetos)
        {
            if (Vector3.Distance(bt.transform.position, obj.transform.position) < 1)
            {
                GameObject.Destroy(obj);
                status = Status.SUCCESS;
                break;
            }
        }
        Print(bt);
        yield break;

        

    }

}