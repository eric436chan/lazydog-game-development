using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{

    public CharacterController controller;
    public GameObject puzzle;
    InteractableObjectImpl highlightScript;
    DialogueTrigger dialogueScript;
   
   
    public float dist;

    private void Start()
    {
        highlightScript = gameObject.GetComponent<InteractableObjectImpl>();
        dialogueScript = gameObject.GetComponent<DialogueTrigger>();
       
       
    }

    // Update is called once per frame
    void Update()
    {

       
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);

        if(dist <= 5f && Input.GetKeyDown(KeyCode.E))
        {
            puzzle.SetActive(false);
           
            Destroy(dialogueScript);
            highlightScript.SetLevel(99);
        }

       


    }
}
