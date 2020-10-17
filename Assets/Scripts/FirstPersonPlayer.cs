using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;


    float speed;
    public float runSpeed = 4f;
    public float walkSpeed = 2f;
    public bool isRunning;


    public bool isJumping;
    public float jump = 3f;
    public float gravity = -9.8f;

    Vector3 velocity;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
        isRunning = false;
        isJumping = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(vertical <= 0.1f && vertical >= -0.1f)
        {
            horizontal = 0f;
        }


        anim.SetFloat("inputH", horizontal);
        anim.SetFloat("inputV", vertical);

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            anim.SetBool("run", true);
        }
        else
        {
            speed = walkSpeed;
            anim.SetBool("run", false);
        }

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetBool("jump", true);
            velocity.y = Mathf.Sqrt(jump * -2 * gravity);
        }
        else
        {
            anim.SetBool("jump", false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

   

}
