using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivroManager : MonoBehaviour
{
    [SerializeField]
    AtivavelLivro[] livrosSlots;

    bool[] livroIColocado = new bool[3];
    bool[] livroIIIColocado = new bool[3];
    bool[] livroXIIIColocado = new bool[3];

    [SerializeField]
    Animator animator;

    private void Update()
    {
        for (int i = 0; i < livrosSlots.Length; i++)
        {
            livroIColocado[i] = livrosSlots[i].livroIEstaColocado;
            livroIIIColocado[i] = livrosSlots[i].livroIIIEstaColocado;
            livroXIIIColocado[i] = livrosSlots[i].livroXIIIEstaColocado;

            if (livroIColocado[i] & livroIIIColocado[i] & livroXIIIColocado[i])
            {
                GetComponent<DialogueTrigger>().TriggerDialogue();

                FindObjectOfType<QuestManager>().todosLivrosNaMesa = true;
            }
        }

        if (livrosSlots[0].livroIEstaColocado & livrosSlots[1].livroIIIEstaColocado & livrosSlots[2].livroXIIIEstaColocado)
        {
            //Vitoria

        }
    }
}
