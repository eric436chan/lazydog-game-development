using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KyleDialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator anim;
    public static KyleDialogueManager instance;

    #region Manager

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion Manager

    public int dialogueNumber = 1;
    public Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void IncrementDialogueNumber()
    {
        dialogueNumber++;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Dialogue Started");
        anim.SetBool("talking", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void EndDialogue()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private IEnumerator Wait()
    {
        anim.SetBool("talking", false);
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<KyleDialogueTrigger>().init = false;
    }
}