using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstPuzzleDoor : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public Animator textAnim;
    public TextMeshProUGUI infoText;
    private float dist;

    private void Update()
    {
        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);

        if (dist <= 5f)
        {
            if (Input.GetKeyDown(KeyCode.E) && !PuzzleManager.instance.isPuzzleOneFinished)
            {
                infoText.text = "Door is locked....";
                textAnim.Play("Out");
            }
        }

        if (PuzzleManager.instance.isPuzzleOneFinished)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            anim.SetBool("IsOpen", PuzzleManager.instance.isPuzzleOneFinished);
            Destroy(this);
        }
    }
}