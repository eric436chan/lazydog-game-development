using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    public CharacterController controller;
    public Animator anim;
    public BoxCollider box;
    float dist;
    public bool isOpen = false;
    // Start is called before the first frame update

    private void Start()
    {
        box = gameObject.GetComponent<BoxCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);

        if(dist <= 5f && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
            anim.SetBool("IsOpen", isOpen);
            box.enabled = !isOpen;
        }
        else if(dist > 5f)
        {
            anim.SetBool("IsOpen", false);
            box.enabled = true;
        }
    }
}
