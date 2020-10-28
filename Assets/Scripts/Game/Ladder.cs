using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    
    // Start is called before the first frame update
    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            float vertical = Input.GetAxis("Vertical");
            if(vertical >= 0.1f)
            {
                other.GetComponent<CharacterController>().Move(transform.up * 4f * Time.deltaTime);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Exit");
        }
    }

  
}
