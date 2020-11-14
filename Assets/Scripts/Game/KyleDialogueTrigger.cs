using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyleDialogueTrigger : MonoBehaviour
{
    public CharacterController controller;

    #region Dialogues

    public Dialogue dialogue1;
    public Dialogue dialogue2;
    public Dialogue dialogue3;
    public Dialogue dialogue4;
    public Dialogue dialogue5;

    #endregion Dialogues

    private Dialogue dialogueToRead;
    private float dist;
    public bool init = false;
    // Start is called before the first frame update

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
                    switch (KyleDialogueManager.instance.dialogueNumber)
                    {
                        case 5:
                            dialogueToRead = dialogue5;
                            break;

                        case 4:
                            dialogueToRead = dialogue4;
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
                    init = !init;
                }
                else
                {
                    KyleDialogueManager.instance.DisplayNextSentence();
                }
            }
        }
        else
        {
            KyleDialogueManager.instance.EndDialogue();
        }
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        KyleDialogueManager.instance.StartDialogue(dialogue);
    }
}