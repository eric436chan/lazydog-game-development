using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{

    public CharacterController controller;
    public float rotationSpeed = 10f;

    float dist;
    

    // Update is called once per frame
    void Update()
    {
        
        gameObject.transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);

        if(dist <= 5f && Input.GetKeyDown(KeyCode.E))
        {
            GameScore.instance.IncrementGameScore();
            Destroy(gameObject);
        }
       
        
        
        
    }
}
