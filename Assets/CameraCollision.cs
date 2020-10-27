using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    Vector3 originalPosition;
    Vector3 finalPosition = new Vector3(-0.367f, 1.1f, 0.25f);


    private void Start()
    {
        originalPosition = transform.localPosition;
        Debug.Log(originalPosition);
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 2f))
        {
            
            transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition, 0.1f);
        }
        else if(transform.localPosition != originalPosition)
        {
           
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, 0.1f);
        }
        
       
    }
}
