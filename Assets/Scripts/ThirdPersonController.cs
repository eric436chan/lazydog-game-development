using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    public Transform camera;
    public Animator anim;

    float speed;
    public float runSpeed = 10f;
    public float walkspeed = 6f;
    public float jumpspeed = 1.5f;
    public float turnSmooth = 0.1f;
    float turnSpeed;

    public float gravity = -9.8f;
    public Transform groundCheck;
    public float groundDist = 0.4f;
    public LayerMask groundLayer;
    bool isGrounded;
    Vector3 velocity;

    private float inputH;
    private float inputV;
    private bool run;
    private bool isSitting;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        speed = walkspeed;
        isSitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        //if (Input.GetKeyDown("1") && !isSitting)
        //{
        //    isSitting = true;
        //    anim.SetBool("isSitting", true);
        //}
        //else if (Input.GetKeyDown("1") && isSitting)
        //{
        //    isSitting = false;
        //    anim.SetBool("isSitting", false);
        //}

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundLayer);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            anim.SetBool("run", true);
        }
        else
        {
            speed = walkspeed;
            anim.SetBool("run", false);
        }


        anim.SetFloat("inputH", horizontal);
        anim.SetFloat("inputV", vertical);

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSpeed, turnSmooth);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //if (Input.GetKey(KeyCode.LeftShift))
            //{
            //    speed = runSpeed;
            //    anim.SetBool("run", true);
            //}
            //else
            //{
            //    speed = walkspeed;
            //    anim.SetBool("run", false);
            //}

            if (isGrounded && velocity.y <= 0f)
            {
                velocity.y = -2f;
            }

            //if (Input.GetKey(KeyCode.Space) && isGrounded)
            //{
            //    anim.SetBool("jump", true);
            //    velocity.y = Mathf.Sqrt(jumpspeed * -2 * gravity);
            //}
            //else
            //{
            //    anim.SetBool("jump", false);
            //}


            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
