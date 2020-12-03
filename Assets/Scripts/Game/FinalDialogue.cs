using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDialogue : MonoBehaviour
{
    public Dialogue finalDialogue;
    private bool final = false;
    public bool init = false;

    public void Update()
    {
        if (init)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                JammoDialogueManager.instance.DisplayNextSentence();
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("works");
            FindObjectOfType<MouseLook>().enabled = false;
            FindObjectOfType<FirstPersonPlayer>().enabled = false;
            FindObjectOfType<PauseMenu>().enabled = false;
            JammoDialogueManager.instance.dialogueNumber = 10;
            JammoDialogueManager.instance.StartDialogue(finalDialogue);

            init = true;
        }
    }
}