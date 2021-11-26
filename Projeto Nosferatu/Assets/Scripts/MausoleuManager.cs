using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MausoleuManager : MonoBehaviour
{
    public bool triggerVermelho = false;
    public bool triggerVerde = false;
    public bool triggerAmarelo = false;
    public bool triggerAzul = false;

    [SerializeField]
    Animator animator;

    private void Update()
    {

        if (triggerVermelho == true & triggerVerde == true && triggerAmarelo == true && triggerAzul == true)
        {
            animator.SetBool("completedQuest", true);
        }
    }
}
