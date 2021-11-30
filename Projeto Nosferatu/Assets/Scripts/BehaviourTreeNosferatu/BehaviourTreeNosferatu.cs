using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class BehaviourTreeNosferatu : MonoBehaviour
{
    public BTNode root;
    public GameObject player;
    public Animator animator;

    public AudioManagerNos audioNos;
    public NavMeshAgent agente;
    NavMeshHit navMeshHit;
    public RuntimeAnimatorController anim1;
    public RuntimeAnimatorController anim2;
    public IEnumerator Begin()
    {
        while(true)
        {
            yield return StartCoroutine(root.Run(this));
        }
    }

    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioNos = GetComponent<AudioManagerNos>();
        Idle();
    }

    void Update()
    {
        agente.SamplePathPosition(NavMesh.AllAreas, 0f, out navMeshHit);
        Debug.Log(navMeshHit.mask);
        if(navMeshHit.mask == 8)
        {
            this.GetComponent<Animator>().runtimeAnimatorController = anim2 as RuntimeAnimatorController;
        }
        else this.GetComponent<Animator>().runtimeAnimatorController = anim1 as RuntimeAnimatorController;
    }

    public void Correndo()
    {
        animator.SetBool("Correndo", true);
        animator.SetBool("Andando", false);
        animator.SetBool("Idle", false);
        animator.SetBool("Olhando", false);
    }

    public void Andando()
    {
        animator.SetBool("Correndo", false);
        animator.SetBool("Andando", true);
        animator.SetBool("Idle", false);
        animator.SetBool("Olhando", false);
    }

    public void Idle()
    {
        animator.SetBool("Correndo", false);
        animator.SetBool("Andando", false);
        animator.SetBool("Idle", true);
        animator.SetBool("Olhando", false);
    }

    public void Olhando()
    {
        animator.SetBool("Olhando", true);
        animator.SetBool("Correndo", false);
        animator.SetBool("Andando", false);
        animator.SetBool("Idle", false);
    }
}
