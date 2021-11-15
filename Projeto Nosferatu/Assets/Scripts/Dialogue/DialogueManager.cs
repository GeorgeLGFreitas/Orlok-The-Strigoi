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

    string name1;
    string name2;

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
                nameText.text = name2;
                break;
            case false:
                nameText.text = name1;
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (sentences.Count == 0 || sentences.Count == 1)
            {
                changeCharacter = !changeCharacter;
            }
            DisplayNextSentence();
        }
    }
}
