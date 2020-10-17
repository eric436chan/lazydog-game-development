using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingDoor : MonoBehaviour
{
    Animator anim;
    public Transform newPos;
    bool hasRider;
    

    private void Start()
    {
      
        hasRider = false;
      
    }
    // Update is called once per frame
    void Update()
    {
        if (hasRider)
        {
            
            transform.position = Vector3.Lerp(transform.position, newPos.position, 0.5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Jammo")
        {
            Debug.Log("on");
            hasRider = true;
            
        }
    }

}
