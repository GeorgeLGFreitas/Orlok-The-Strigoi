using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField]
    bool isPlayerTrigger;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isPlayerTrigger)
            {
                TriggerDialogue();
                Destroy(gameObject);
            }
        }
    }
}
