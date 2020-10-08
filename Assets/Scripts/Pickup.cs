using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform grabPos;
    GameObject currentlyGrabbed;
    float dist;
    public LayerMask itemLayer;

    private void Start()
    {
       
    }

    private void Update()
    {
        Collider[] hit = Physics.OverlapSphere(gameObject.transform.position, 5f, itemLayer);

        foreach(Collider go in hit)
        {
            if(currentlyGrabbed != null)
            {
                break;
            }
            dist = Vector3.Distance(gameObject.transform.position, go.gameObject.transform.position);

            if (dist <= 5f && Input.GetKey(KeyCode.E))
            {
                currentlyGrabbed = go.gameObject;
                go.gameObject.GetComponent<Rigidbody>().useGravity = false;
                go.gameObject.transform.position = grabPos.position;
                go.gameObject.transform.parent = GameObject.Find("Destination").transform;

            }
            else
            {
                go.gameObject.transform.parent = null;
                go.gameObject.GetComponent<Rigidbody>().useGravity = true;
            }

        }
        

    }

    //private void OnMouseOver()
    //{
    //    if (Input.GetKey(KeyCode.E) && dist < 7.5f)
    //    {
    //        renderer.material.SetFloat("Boolean_A02DFE45", 1f);
    //        gameObject.GetComponent<Rigidbody>().useGravity = false;
    //        gameObject.transform.position = grabPos.position;
    //        gameObject.transform.parent = GameObject.Find("Destination").transform;
    //    }
    //    else
    //    {
    //        gameObject.transform.parent = null;
    //        gameObject.GetComponent<Rigidbody>().useGravity = true;
    //    }
    //}
}
