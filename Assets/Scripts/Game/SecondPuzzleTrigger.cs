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
    }

    private void OnMouseOver()
    {
        if (dist <= 5f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Inventory.instance.inventory.Count == 0)
                {
                    infoText.text = "I need a tool to fix this...";
                    textAnim.Play("Out");
                }
                else if (!Inventory.instance.inventory.Contains(keyItem))
                {
                    infoText.text = "This is not the correct tool...";
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