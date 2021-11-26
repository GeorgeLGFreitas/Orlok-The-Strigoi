using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivroManager : MonoBehaviour
{
    [SerializeField]
    AtivavelLivro[] livrosSlots;

    public bool[] livroIColocado = new bool[3];
    public bool[] livroIIIColocado = new bool[3];
    public bool[] livroXIIIColocado = new bool[3];

    [SerializeField]
    Animator animator;

    private void Update()
    {
        for (int i = 0; i < livrosSlots.Length; i++)
        {
            livroIColocado[i] = livrosSlots[i].livroIEstaColocado;
            livroIIIColocado[i] = livrosSlots[i].livroIIIEstaColocado;
            livroXIIIColocado[i] = livrosSlots[i].livroXIIIEstaColocado;

            if (livroIColocado[i] & livroXIIIColocado[i])
            {
                GetComponent<DialogueTrigger>().TriggerDialogue();

                FindObjectOfType<QuestManager>().todosLivrosNaMesa = true;

                animator.SetBool("escadaOpen", true);
            }
        }

        if (livrosSlots[0].livroIEstaColocado & livrosSlots[1].livroIIIEstaColocado & livrosSlots[2].livroXIIIEstaColocado)
        {
            //Vitoria
            animator.SetBool("escadaOpen", true);
        }
    }
}
