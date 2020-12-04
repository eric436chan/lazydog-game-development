using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public CharacterController controller;
    private float dist;
    public Transform destination;
    private bool selected = false;

    // Update is called once per frame
    private void Update()
    {
        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);

        if (dist <= 5f && selected)
        {
            if (Input.GetMouseButton(0))
            {
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.transform.position = controller.transform.position + controller.transform.forward * 3f;
                gameObject.transform.rotation = new Quaternion(0f, controller.transform.rotation.y, 0f, controller.transform.rotation.w);
            }
            else
            {
                selected = false;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    private void OnMouseOver()
    {
        selected = true;
    }

    //private void OnMouseExit()
    //{
    //    selected = false;
    //}
}