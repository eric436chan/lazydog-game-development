using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwoDest : MonoBehaviour
{
    private Vector3 currentDest;
    public int pivotPoint = 0;
    public Animator anim;

    private void Start()
    {
        pivotPoint = 1;
        gameObject.transform.position = new Vector3(-16.5f, 4.5f, -29.4f);
        currentDest = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jammo")
        {
            pivotPoint++;
        }
    }

    private void Update()
    {
        switch (pivotPoint)
        {
            case 6:
                anim.SetBool("isWalking", false);
                Destroy(FindObjectOfType<JammoPuzzleTwoAI>());
                FindObjectOfType<JammoDialogueTrigger>().enabled = true;

                break;

            case 5:
                currentDest = new Vector3(-77.7f, 4.5f, -41.56f);
                break;

            case 4:
                currentDest = new Vector3(-65f, 4.5f, -30.7f);
                break;

            case 3:
                currentDest = new Vector3(-43.7f, 4.5f, -30.7f);
                break;

            case 2:
                currentDest = new Vector3(-35.79f, 4.5f, -25.39f);
                break;

            case 1:
                currentDest = new Vector3(-16.5f, 4.5f, -25.39f);

                break;
        }

        gameObject.transform.position = currentDest;

        if (FindObjectOfType<JammoDialogueTrigger>().enabled == true)
        {
            anim.SetBool("isWalking", false);
        }
    }
}