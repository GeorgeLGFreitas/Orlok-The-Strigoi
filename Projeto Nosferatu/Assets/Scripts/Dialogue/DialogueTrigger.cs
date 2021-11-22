using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField]
    bool isPlayerTrigger = false;

    [SerializeField]
    int[] mudancaPersonagem;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().mudancaDePersonagem = mudancaPersonagem;
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
