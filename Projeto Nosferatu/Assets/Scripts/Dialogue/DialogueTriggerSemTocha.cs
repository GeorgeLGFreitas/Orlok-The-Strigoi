using UnityEngine;

public class DialogueTriggerSemTocha : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField]
    Jogador jogador;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (jogador.tocha == false)
            {
                TriggerDialogue();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
