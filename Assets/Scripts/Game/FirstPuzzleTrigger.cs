using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuzzleTrigger : MonoBehaviour
{

    public CharacterController controller;
    public GameObject puzzle;
    InteractableObjectImpl highlightScript;
  
    public float dist;

    private void Start()
    {
        highlightScript = gameObject.GetComponent<InteractableObjectImpl>();
    }

    // Update is called once per frame
    void Update()
    {

       
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);

        if(dist <= 5f && Input.GetKeyDown(KeyCode.E))
        {
            puzzle.SetActive(false);
            JammoDialogueManager.instance.dialogueNumber = 3;
            PuzzleManager.instance.isPuzzleOneFinished = true;
            highlightScript.SetLevel(99);
            FindObjectOfType<JammoPuzzleOneAI>().enabled = true;
            FindObjectOfType<PuzzleOneDest>().enabled = true;
            Destroy(this);
        }

       


    }
}
