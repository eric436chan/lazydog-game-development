using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KyleDialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Animator dialogueAnim;
    public Animator kyleAnim;
    public static KyleDialogueManager instance;
    public GameObject inventoryPanel;
    public bool open = false;

    public CharacterController controller;
    public GameObject npc;

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
        //if (!open)
        //{
        //    inventoryPanel.SetActive(false);
        //}

        //Vector3 delta = new Vector3(controller.transform.position.x - npc.transform.position.x, 0f, controller.transform.position.z - npc.transform.position.z);
        //Quaternion rotation = Quaternion.LookRotation(delta);
        //while (npc.transform.rotation != rotation)
        //{
        //    npc.transform.rotation = Quaternion.Lerp(npc.transform.rotation, rotation, Time.time * 0.1f);
        //}

        kyleAnim.SetBool("isTalking", true);
        dialogueAnim.SetBool("kyleOpen", true);
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
        kyleAnim.SetBool("isTalking", false);
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
        dialogueAnim.SetBool("kyleOpen", false);
        //if (open && JammoDialogueManager.instance.open)
        //{
        //    inventoryPanel.SetActive(true);
        //}

        if (dialogueNumber == 1 && FindObjectOfType<KyleDialogueTrigger>().init)
        {
            FindObjectOfType<KyleLabDest>().enabled = true;
            FindObjectOfType<KyleLabAI>().enabled = true;
            IncrementDialogueNumber();
        }

        if (dialogueNumber == 2 && JammoDialogueManager.instance.dialogueNumber == 9)
        {
            IncrementDialogueNumber();
        }

        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<KyleDialogueTrigger>().init = false;
        FindObjectOfType<MouseLook>().enabled = true;
        FindObjectOfType<FirstPersonPlayer>().enabled = true;
        FindObjectOfType<PauseMenu>().enabled = true;
    }
}