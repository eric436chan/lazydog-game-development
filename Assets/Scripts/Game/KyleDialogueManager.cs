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
    public GameObject inventoryPanel;
    public bool open = false;

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
        open = false;
        if (!open)
        {
            inventoryPanel.SetActive(false);
        }

        anim.SetBool("kyleOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        switch (dialogueNumber)
        {
            case 1:
                AudioManager.instance.Play("KyleHello");
                break;

            default:
                AudioManager.instance.Play("KyleWait");
                break;
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
        open = true;
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
        anim.SetBool("kyleOpen", false);
        if (open && JammoDialogueManager.instance.open)
        {
            inventoryPanel.SetActive(true);
        }

        if (dialogueNumber == 2 && FindObjectOfType<KyleDialogueTrigger>().init)
        {
            FindObjectOfType<KyleLabDest>().enabled = true;
            FindObjectOfType<KyleLabAI>().enabled = true;
        }

        if (dialogueNumber == 2 && JammoDialogueManager.instance.dialogueNumber == 9)
        {
            IncrementDialogueNumber();
        }

        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<KyleDialogueTrigger>().init = false;
    }
}