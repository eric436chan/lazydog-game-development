using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuzzleTrigger : MonoBehaviour
{
    public CharacterController controller;
    public GameObject puzzle;
    private InteractableObjectImpl highlightScript;
    public Texture2D cursor;
    public float dist;

    private void Start()
    {
        highlightScript = gameObject.GetComponent<InteractableObjectImpl>();
    }

    public void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);
    }

    private void OnMouseOver()
    {
        if (dist <= 5f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                puzzle.SetActive(false);
                JammoDialogueManager.instance.dialogueNumber = 3;
                PuzzleManager.instance.isPuzzleOneFinished = true;
                highlightScript.SetLevel(99);
                FindObjectOfType<JammoPuzzleOneAI>().enabled = true;
                FindObjectOfType<PuzzleOneDest>().enabled = true;
                gameObject.tag = "Untagged";
                Destroy(this);
            }
        }
    }
}