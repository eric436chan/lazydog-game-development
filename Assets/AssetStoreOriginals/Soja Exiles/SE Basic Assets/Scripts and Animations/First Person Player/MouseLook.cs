using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseXSensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;
    private Ray ray;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseXSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5f))
        {
            if (hit.collider.tag == "Door" || hit.collider.tag == "Puzzle" || hit.collider.tag == "Key Item" || hit.collider.tag == "Burger" || hit.collider.tag == "Waffle" || hit.collider.tag == "Cake")
            {
                Cursor.visible = true;
            }
            else
            {
                Cursor.visible = false;
            }
        }
    }

    //private void FixedUpdate()
    //{
    //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, 5f))
    //    {
    //        if (hit.collider.tag == "Door" || hit.collider.tag == "Puzzle" || hit.collider.tag == "Key Item")
    //        {
    //            Cursor.visible = true;
    //        }
    //        else
    //        {
    //            Cursor.visible = false;
    //        }
    //    }
    //}
}