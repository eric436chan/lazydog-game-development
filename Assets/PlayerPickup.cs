using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public CharacterController controller;
    private float dist;
    public Transform destination;

    // Update is called once per frame
    private void Update()
    {
        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);
    }

    private void OnMouseOver()
    {
        if (dist <= 7f)
        {
            if (Input.GetMouseButton(0))
            {
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.transform.position = destination.position;
                transform.parent = GameObject.Find("Destination").transform;
            }
            else
            {
                transform.parent = null;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }
}