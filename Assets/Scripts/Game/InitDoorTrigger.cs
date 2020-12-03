using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitDoorTrigger : MonoBehaviour
{

    public CharacterController controller;
    public Animator anim;
    float dist;
    
    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);
        anim.SetFloat("Dist", dist);

        if(dist <= 5f)
        {
            GetComponent<BoxCollider>().enabled = false;
            
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
           
        }
    }
}
