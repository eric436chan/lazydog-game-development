using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPuzzleDoor : MonoBehaviour
{


    public CharacterController controller;
    public Animator anim;
    float dist;
    
   

    
    void Update()
    {
        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);

        if(dist <= 5f)
        {
            if (Input.GetKeyDown(KeyCode.E) && !PuzzleManager.instance.isPuzzleOneFinished)
            {
                Debug.Log("Door is locked");
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
