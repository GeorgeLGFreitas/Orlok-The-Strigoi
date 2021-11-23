using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BehaviourTreeNosferatu : MonoBehaviour
{
    public BTNode root;
    public GameObject player;

    public NavMeshAgent agente;
    
    public IEnumerator Begin()
    {
        while(true)
        {
            yield return StartCoroutine(root.Run(this));
        }
    }

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }
}
