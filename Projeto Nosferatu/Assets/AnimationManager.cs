using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;

    public Jogador jogador;
    public CannonController cannon;
    public Movimento movimento;
    public Visao visao;
   
    void Awake()
    {
        
    }
    void Update()
    {
        
        if(movimento.movi.x > 0 || movimento.movi.z > 0 )
        {
            andando();
        }
        else animator.SetBool("Andando",false); 
    }
    public void Idle()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }

    void morrendoCima()
    {
        animator.SetTrigger("MDCima");
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }

    void morrendoFrente()
    {
        animator.SetTrigger("MDFrente");
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }

     void andando()
    {
        animator.SetBool("Andando",true);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }

     void correndo()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",true);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }
    public void bebendo()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",true);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }

    public void arremesso()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",true);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }


     void andandoTocha()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",true);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }

     void correndoTocha()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",true);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }

    

     void bebendoTocha()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",true);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",true);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }
    void aremessoTocha()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",true);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",false);
    }

    public void GITocha()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",true);
        animator.SetBool("GI",false);
    }

    public void GI()
    {
        animator.SetBool("Andando",false);
        animator.SetBool("Correndo",false);
        animator.SetBool("Bebendo",false);
        animator.SetBool("Arremesso",false);
        animator.SetBool("AndandoTocha",false);
        animator.SetBool("CorrendoTocha",false);
        animator.SetBool("BebendoTocha",false);
        animator.SetBool("ArremessoTocha",false);
        animator.SetBool("GITocha",false);
        animator.SetBool("GI",true);
    }
}
