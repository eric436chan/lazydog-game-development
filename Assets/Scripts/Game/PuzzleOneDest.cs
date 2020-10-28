using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOneDest : MonoBehaviour
{
    Vector3 currentDest;
    int pivotPoint = 0;
    private void Start()
    {
        gameObject.transform.position = new Vector3(8.75f, 4.5f, -29.4f);
        currentDest = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Jammo")
        {
            pivotPoint++;
        }
    }

    private void Update()
    {
        switch (pivotPoint)
        {
            case 2:
                
                Destroy(FindObjectOfType<JammoPuzzleOneAI>());
                FindObjectOfType<JammoDialogueTrigger>().enabled = true;
                Destroy(this);
               
                break;
            case 1:
                currentDest = new Vector3(-16.5f, 4.5f, -29.4f);

                break;

            
        }

        gameObject.transform.position = currentDest;

    }
}
