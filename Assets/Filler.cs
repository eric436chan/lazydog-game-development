using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filler : MonoBehaviour
{
    public CharacterController controller;
    float dist;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);

        if(dist <= 3f && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("This is a filler feature that the team has not yet implemented! Come back soon to see any changes!");
        }
    }
}
