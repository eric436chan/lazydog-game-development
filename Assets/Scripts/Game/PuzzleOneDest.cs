using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOneDest : MonoBehaviour
{
    public Animator anim;
    private Vector3 currentDest;
    public int pivotPoint = 0;

    private void Start()
    {
        pivotPoint = 0;
        gameObject.transform.position = new Vector3(8.75f, 4.5f, -29.4f);
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
            case 2:

                Destroy(FindObjectOfType<JammoPuzzleOneAI>());
                FindObjectOfType<JammoDialogueTrigger>().enabled = true;
                FindObjectOfType<JammoPuzzleOneAI>().anim.SetBool("isWalking", false);
                //anim.SetBool("isWalking", true);
                Destroy(this);

                break;

            case 1:
                currentDest = new Vector3(-16.5f, 4.5f, -29.4f);
                //anim.SetBool("isWalking", true);
                break;
        }

        gameObject.transform.position = currentDest;

        if (FindObjectOfType<JammoDialogueTrigger>().enabled == true)
        {
            anim.SetBool("isWalking", false);
        }
    }
}