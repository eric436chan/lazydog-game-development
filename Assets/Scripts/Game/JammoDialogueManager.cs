using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JammoDialogueManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Text nameText;
    public Text dialogueText;
    public Animator anim;
    public Animator jammoAnim;
    public static JammoDialogueManager instance;
    public GameObject inventoryPanel;

    public Item key;

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
        inventoryPanel.SetActive(false);
        Debug.Log("Dialogue Started");
        anim.SetBool("isOpen", true);
        jammoAnim.SetBool("isTalking", true);

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
        jammoAnim.SetBool("isTalking", false);
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
        anim.SetBool("isOpen", false);
        inventoryPanel.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        if (dialogueNumber == 1 && FindObjectOfType<JammoDialogueTrigger>().init)
        {
            Inventory.instance.addItem(key);
            IncrementDialogueNumber();
        }

        if (dialogueNumber == 3 && FindObjectOfType<JammoDialogueTrigger>().init)
        {
            IncrementDialogueNumber();
            Inventory.instance.clearInventory();
        }

        if (dialogueNumber == 6 && FindObjectOfType<JammoDialogueTrigger>().init)
        {
            IncrementDialogueNumber();
            Inventory.instance.clearInventory();
            FindObjectOfType<AfterElevDest>().pivotPoint = 4;
        }

        FindObjectOfType<JammoDialogueTrigger>().init = false;
    }
}