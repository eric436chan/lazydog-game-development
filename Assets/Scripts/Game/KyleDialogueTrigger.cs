﻿using System.Collections;
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
    public Dialogue dialogue6;
    public Dialogue dialogue7;

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
                /*Vector3 playerPos = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
                Vector3 npcPos = GameObject.FindGameObjectsWithTag("Kyle")[0].transform.position; ;
                Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);

                Quaternion rotation = Quaternion.LookRotation(delta);

                */

                Vector3 delta = new Vector3(controller.transform.position.x - transform.position.x, 0f, controller.transform.position.z - transform.position.z);
                Quaternion rotation = Quaternion.LookRotation(delta);

                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.time * 60f);

                FindObjectOfType<MouseLook>().enabled = false;
                FindObjectOfType<FirstPersonPlayer>().enabled = false;
                FindObjectOfType<PauseMenu>().enabled = false;
                if (!init)
                {
                    switch (KyleDialogueManager.instance.dialogueNumber)
                    {
                        case 7:
                            dialogueToRead = dialogue7;
                            break;

                        case 6:
                            dialogueToRead = dialogue6;
                            break;

                        case 5:
                            dialogueToRead = dialogue5;
                            KyleDialogueManager.instance.IncrementDialogueNumber();
                            break;

                        case 4:
                            dialogueToRead = dialogue4;
                            break;

                        case 3:
                            dialogueToRead = dialogue3;
                            KyleDialogueManager.instance.IncrementDialogueNumber();
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
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        KyleDialogueManager.instance.StartDialogue(dialogue);
    }
}