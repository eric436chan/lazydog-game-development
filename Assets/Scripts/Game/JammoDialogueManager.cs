using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JammoDialogueManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Text nameText;
    public Text dialogueText;
    public Animator anim;
    public Animator jammoAnim;
    public static JammoDialogueManager instance;
    public GameObject inventoryPanel;
    public bool open = false;
    public Item key;

    public Animator fadePanelAnim;

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
        open = false;

        //if (!open)
        //{
        //    inventoryPanel.SetActive(false);
        //}

        //Vector3 delta = new Vector3(controller.transform.position.x - npc.transform.position.x, 0f, controller.transform.position.z - npc.transform.position.z);
        //npc.transform.rotation = Quaternion.LookRotation(delta);

        Debug.Log("Dialogue Started");
        anim.SetBool("isOpen", true);
        jammoAnim.SetBool("isTalking", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        switch (dialogueNumber)
        {
            case 1:
                AudioManager.instance.Play("JammoHello");
                break;

            case 3:
                AudioManager.instance.Play("JammoSurprise");
                break;

            case 6:
                AudioManager.instance.Play("JammoSurprise");
                break;

            case 10:
                break;

            default:
                AudioManager.instance.Play("JammoWait");
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

    private IEnumerator Fade()
    {
        fadePanelAnim.SetBool("End", true);
        Cursor.visible = false;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }

    private IEnumerator Wait()
    {
        anim.SetBool("isOpen", false);
        //if (open && KyleDialogueManager.instance.open)
        //{
        //    inventoryPanel.SetActive(true);
        //}

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

        if (dialogueNumber == 9 && FindObjectOfType<JammoDialogueTrigger>().init)
        {
            FindObjectOfType<JammoLabDest>().enabled = true;
            FindObjectOfType<JammoLabAI>().enabled = true;
        }

        if (dialogueNumber == 10 && FindObjectOfType<FinalDialogue>().init)
        {
            Debug.Log("Game ends");
            StartCoroutine(Fade());
        }

        FindObjectOfType<JammoDialogueTrigger>().init = false;
        FindObjectOfType<MouseLook>().enabled = true;
        FindObjectOfType<FirstPersonPlayer>().enabled = true;
        FindObjectOfType<PauseMenu>().enabled = true;
        //FindObjectOfType<FinalDialogue>().init = false;
    }
}