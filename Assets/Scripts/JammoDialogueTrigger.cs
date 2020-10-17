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
    #endregion


    Dialogue dialogueToRead;
    float dist;
    public bool init = false;

    // Update is called once per frame
    void Update()
    {

        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);

        if (dist <= 5f )
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!init)
                {
                    switch (JammoDialogueManager.instance.dialogueNumber)
                    {

                        case 5:
                            dialogueToRead = dialogue5;
                            break;
                        case 4:
                            dialogueToRead = dialogue4;
                            break;
                        case 3:
                            dialogueToRead = dialogue3;
                            JammoDialogueManager.instance.IncrementDialogueNumber();
                            FindObjectOfType<PuzzleTwoDest>().enabled = true;
                            FindObjectOfType<JammoPuzzleTwoAI>().enabled = true;
                            break;
                        case 2:
                            dialogueToRead = dialogue2;
                            break;
                        case 1:
                            dialogueToRead = dialogue1;
                            JammoDialogueManager.instance.IncrementDialogueNumber();
                            break;
                    }
                    TriggerDialogue(dialogueToRead);
                    init = !init;

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
        JammoDialogueManager.instance.StartDialogue(dialogue);
    }
}
