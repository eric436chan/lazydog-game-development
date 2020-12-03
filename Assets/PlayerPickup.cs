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

        if (selected)
        {
            if (Input.GetMouseButton(0))
            {
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.transform.position = controller.transform.position + controller.transform.forward * 3f;
                gameObject.transform.rotation = new Quaternion(0f, controller.transform.rotation.y, 0f, controller.transform.rotation.w);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                selected = false;
            }
        }
    }

    private void OnMouseOver()
    {
        selected = true;
        //if (dist <= 5f)
        //{
        //    if (Input.GetMouseButton(0))
        //    {
        //        gameObject.GetComponent<Rigidbody>().useGravity = false;
        //        gameObject.transform.position = controller.transform.position + controller.transform.forward * 5;
        //        gameObject.transform.rotation = new Quaternion(0f, controller.transform.rotation.y, 0f, controller.transform.rotation.w);
        //        //transform.parent = GameObject.Find("Destination").transform;
        //    }
        //    else
        //    {
        //        //transform.parent = null;
        //        gameObject.GetComponent<Rigidbody>().useGravity = true;
        //    }
        //}
    }

    //private void OnMouseExit()
    //{
    //    selected = false;
    //    gameObject.GetComponent<Rigidbody>().useGravity = true;
    //}
}