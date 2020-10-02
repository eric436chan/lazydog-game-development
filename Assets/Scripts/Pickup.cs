using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    MeshRenderer renderer;
    public Transform grabPos;
    public CharacterController controller;
    float dist;

    private void Start()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);
    }

    private void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.E) && dist < 7.5f)
        {
            renderer.material.SetFloat("Boolean_A02DFE45", 1f);
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.transform.position = grabPos.position;
            gameObject.transform.parent = GameObject.Find("Destination").transform;
        }
        else
        {
            gameObject.transform.parent = null;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
