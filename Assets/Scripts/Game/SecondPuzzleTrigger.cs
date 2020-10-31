using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondPuzzleTrigger : MonoBehaviour
{
    public CharacterController controller;
    private float dist;
    public GameObject puzzle;
    private InteractableObjectImpl highlightScript;
    public Item keyItem;
    public Animator textAnim;
    public TextMeshProUGUI infoText;

    private void Start()
    {
        highlightScript = gameObject.GetComponent<InteractableObjectImpl>();
    }

    // Update is called once per frame
    private void Update()
    {
        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);

        if (dist <= 5f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!Inventory.instance.inventory.Contains(keyItem))
                {
                    infoText.text = "I need a tool to fix this...";
                    textAnim.Play("Out");
                }
                else
                {
                    PuzzleManager.instance.puzzleTwoFixed++;
                    highlightScript.SetLevel(99);
                    puzzle.SetActive(false);
                    Destroy(this);
                }
            }
        }
    }
}