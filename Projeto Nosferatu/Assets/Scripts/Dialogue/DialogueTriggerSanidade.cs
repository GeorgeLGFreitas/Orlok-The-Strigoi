using UnityEngine;

public class DialogueTriggerSanidade : MonoBehaviour
{
    public Dialogue dialogue;

    Stats playerStats;

    [SerializeField]
    float nivelSanidadeTrigger;

    [SerializeField]
    int[] mudancaPersonagem;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().mudancaDePersonagem = mudancaPersonagem;
    }

    private void Start()
    {
        playerStats = gameObject.GetComponent<Stats>();
    }
    private void Update()
    {
        if (playerStats.atualSanidade <= nivelSanidadeTrigger && playerStats.atualSanidade >= nivelSanidadeTrigger - 1)
        {
            TriggerDialogue();
        }
    }

}
