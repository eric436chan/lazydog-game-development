using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;

    float moveSpeed = 4f;
    float walkSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        anim.SetFloat("Horizontal", x);
        anim.SetFloat("Vertical", z);

        Vector3 move;
        if (z <= 0)
        {
            move = transform.forward * z * walkSpeed;
            anim.SetFloat("Horizontal", 0);
        }
        else
        {
            move = (transform.right * x + transform.forward * z)*moveSpeed;
        }
        

        controller.Move(move * Time.deltaTime);

    }

}
