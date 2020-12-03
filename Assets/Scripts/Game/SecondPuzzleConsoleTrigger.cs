using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondPuzzleConsoleTrigger : MonoBehaviour
{
    public CharacterController controller;
    private float dist;
    public Animator textAnim;
    public TextMeshProUGUI infoText;

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
                if (PuzzleManager.instance.puzzleTwoFixed == 3)
                {
                    if (FindObjectOfType<PuzzleTwoDest>().pivotPoint != 6)
                    {
                        infoText.text = "Please wait for Jammo...";
                        textAnim.Play("Out");
                    }
                    else
                    {
                        Destroy(FindObjectOfType<PuzzleTwoDest>());
                        PuzzleManager.instance.isPuzzleTwoFinished = true;
                        Destroy(this);
                    }
                }
                else
                {
                    infoText.text = "Not enough power...";
                    textAnim.Play("Out");
                }
            }
        }
    }
}