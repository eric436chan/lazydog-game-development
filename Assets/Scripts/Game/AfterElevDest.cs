using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterElevDest : MonoBehaviour
{
    public Animator anim;
    private Vector3 currentDest;
    public int pivotPoint = 0;

    private void Start()
    {
        pivotPoint = 0;
        gameObject.transform.position = new Vector3(-77f, 16f, -18f);
        currentDest = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jammo")
        {
            pivotPoint++;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        switch (pivotPoint)
        {
            case 6:
                FindObjectOfType<JammoDialogueTrigger>().enabled = true;
                anim.SetBool("isWalking", false);
                Destroy(FindObjectOfType<JammoAfterElevAI2>());
                break;

            case 5:
                currentDest = new Vector3(-147.5f, 5.35f, -146.3f);
                break;

            case 4:
                currentDest = new Vector3(-147.5f, 16.227f, -18f);
                FindObjectOfType<JammoAfterElevAI2>().enabled = true;

                break;

            case 1:
                FindObjectOfType<JammoDialogueTrigger>().enabled = true;
                anim.SetBool("isWalking", false);
                Destroy(FindObjectOfType<JammoAfterElevAI>());
                JammoDialogueManager.instance.IncrementDialogueNumber();
                pivotPoint++;
                break;
        }
        gameObject.transform.position = currentDest;
    }
}