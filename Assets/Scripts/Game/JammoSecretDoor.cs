using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JammoSecretDoor : MonoBehaviour
{
    public GameObject npc;
    private float dist;
    private Animator anim;
    // Update is called once per frame

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        dist = Vector3.Distance(npc.transform.position, gameObject.transform.position);

        if (dist <= 5f)
        {
            anim.SetBool("isOpen", true);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            anim.SetBool("isOpen", false);
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //add code to state it's locked
        }
    }
}