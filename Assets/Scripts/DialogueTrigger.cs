using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public CharacterController controller;
    public float dist;
    public bool init = false;

    private void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);
        if (dist <= 3.5f && !init && Input.GetKeyDown(KeyCode.E))
        {

            TriggerDialogue();
            init = true;
        }
        else if (dist <= 3.5f && init && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager.instance.DisplayNextSentence();

        }

        if (dist > 3.5f)
        {
            init = false;
        }


    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }





}
