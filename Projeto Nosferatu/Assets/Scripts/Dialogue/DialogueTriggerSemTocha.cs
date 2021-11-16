using UnityEngine;

public class DialogueTriggerSemTocha : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField]
    Jogador jogador;

    [SerializeField]
    int mudancaPersonagem;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().mudancaDePersonagem = mudancaPersonagem;
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
