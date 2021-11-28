using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    public GameObject atencao;
    public Jogador jogador;
    public CannonController cannon;
    public Movimento movimento;
    public Visao visao;
    public GameObject tocha;
    public RuntimeAnimatorController anim1;
    public RuntimeAnimatorController anim2;
   
    void Awake()
    {
        
    }
    void Update()
    {
        
        if(movimento.movi.x > 0f || movimento.movi.z > 0f )
        {
            andando();
            if(movimento.corre)
            {
                correndo();
            }
            
        }
        else animator.SetBool("Andando",false); 

        if(tocha.active == true)
        {
            animator.runtimeAnimatorController = anim2 as RuntimeAnimatorController;
        }
        else animator.runtimeAnimatorController = anim1 as RuntimeAnimatorController;
    }
    public void Idle()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("GI",false);
    }

    void morrendoCima()
    {
        animator.SetTrigger("MDCima");
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("GI",false);
    }

    void morrendoFrente()
    {
        animator.SetTrigger("MDFrente");
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("GI",false);
    }

     void andando()
    {
        animator.SetBool("Andando",true);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("GI",false);
    }

     void correndo()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",true);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("GI",false);
    }
    public void bebendo()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",true);
        animator.SetBool("Arremesso",false);
        animator.SetBool("GI",false);
    }

    public void arremesso()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",true);
        animator.SetBool("GI",false);
    }
    public void GI()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("GI",true);
    }

    public void Atencao()
    {
       Instantiate(atencao, transform.position, Quaternion.identity);
    }
}
