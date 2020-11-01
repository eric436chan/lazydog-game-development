using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammoDialogueTrigger : MonoBehaviour
{
    public CharacterController controller;

    #region Dialogue Holder

    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public Dialogue dialogue4;
    public Dialogue dialogue5;
    public Dialogue dialogue6;

    #endregion Dialogue Holder

    private Dialogue dialogueToRead;
    private float dist;
    public bool init = false;

    // Update is called once per frame
    private void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);

        if (dist <= 5f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!init)
                {
                    switch (JammoDialogueManager.instance.dialogueNumber)
                    {
                        case 6:
                            dialogueToRead = dialogue6;

                            break;

                        case 5:
                            dialogueToRead = dialogue5;
                            FindObjectOfType<PuzzleTwoDest>().enabled = true;
                            FindObjectOfType<JammoPuzzleTwoAI>().enabled = true;
                            break;

                        case 4:
                            dialogueToRead = dialogue4;
                            JammoDialogueManager.instance.IncrementDialogueNumber();
                            break;

                        case 3:
                            dialogueToRead = dialogue3;

                            break;

                        case 2:
                            dialogueToRead = dialogue2;
                            break;

                        case 1:
                            dialogueToRead = dialogue1;

                            break;
                    }
                    TriggerDialogue(dialogueToRead);
                }
                else
                {
                    JammoDialogueManager.instance.DisplayNextSentence();
                }
            }
        }
        else
        {
            JammoDialogueManager.instance.EndDialogue();
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        init = !init;
        JammoDialogueManager.instance.StartDialogue(dialogue);
    }
}