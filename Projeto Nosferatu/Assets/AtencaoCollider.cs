using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AtencaoCollider : MonoBehaviour
{
    NavMeshAgent agent;
    public Jogador player;
    // Start is called before the first frame update
    void Start()
    {
       player =  FindObjectOfType<Jogador>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Pedra"))
        {
            //agent.SetDestination(player.transform.position);
            //Destroy(other.gameObject);
        }
    }
}
