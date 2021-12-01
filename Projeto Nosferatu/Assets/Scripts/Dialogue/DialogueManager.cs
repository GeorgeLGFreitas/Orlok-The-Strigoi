using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    float tempoTimer;
    float timer;
    bool onDialogue = false;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;

    bool changeCharacter = false;

    public bool triggerQuest = false;

    public int[] mudancaDePersonagem;

    string name1;
    string name2;

    [SerializeField]
    Stats stats;

    private void Start()
    {
        sentences = new Queue<string>();
        timer = tempoTimer;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        onDialogue = true;

        nameText.text = dialogue.name;

        name1 = dialogue.name;
        name2 = dialogue.name2;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Debug.Log(sentences);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        switch (changeCharacter)
        {
            case true:
                nameText.text = name1;
                break;
            case false:
                nameText.text = name2;
                break;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        timer = tempoTimer;  
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
        onDialogue = false;

        if (stats.atualSanidade <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (triggerQuest == true)
        {
            FindObjectOfType<QuestManager>().acharDisco = true;
        }
    }

    private void Update()
    {
        if (onDialogue)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                for (int i = 0; i < mudancaDePersonagem.Length; i++)
                {
                    if (sentences.Count == mudancaDePersonagem[i])
                    {
                        changeCharacter = !changeCharacter;

                    }
                }

                DisplayNextSentence();

                timer = tempoTimer;
            }


            if (Input.GetKeyDown(KeyCode.Space))
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
}
