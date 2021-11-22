using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    bool firstQuest = false;
    bool changeCharacter = false;

    public int[] mudancaDePersonagem;

    string name1;
    string name2;

    [SerializeField]
    Stats stats;
    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);


        nameText.text = dialogue.name;

        name1 = dialogue.name;
        name2 = dialogue.name2;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        switch (changeCharacter)
        {
            case true:
                nameText.text = name1;
                break;
            case false:
                nameText.text = name2;
                break;
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        if (!firstQuest)
        {
            QuestManager questManager = FindObjectOfType<QuestManager>();
            questManager.firtsQuest = true;
            firstQuest = true;
        }
        if (stats.atualSanidade <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < mudancaDePersonagem.Length; i++)
            {
                if (sentences.Count == mudancaDePersonagem[i])
                {
                    changeCharacter = !changeCharacter;
                }
            }
            
            DisplayNextSentence();
        }
    }
}
