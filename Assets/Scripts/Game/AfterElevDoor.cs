using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterElevDoor : MonoBehaviour
{
    public CharacterController controller;
    private Animator anim;
    private float dist;
    private float dist2;
    public GameObject npc;

    // Start is called before the first frame update
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);
        dist2 = Vector3.Distance(npc.transform.position, gameObject.transform.position);

        if (dist <= 5f || dist2 <= 5f)
        {
            if (JammoDialogueManager.instance.dialogueNumber >= 6)
            {
                anim.SetBool("isOpen", true);
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            anim.SetBool("isOpen", false);
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}