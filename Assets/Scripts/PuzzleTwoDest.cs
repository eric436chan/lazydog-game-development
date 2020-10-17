using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwoDest : MonoBehaviour
{
    Vector3 currentDest;
    int pivotPoint = 0;
    private void Start()
    {
        gameObject.transform.position = new Vector3(-16.5f, 4.5f, -29.4f);
        currentDest = gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jammo")
        {
            pivotPoint++;
        }
    }

    private void Update()
    {
        switch (pivotPoint)
        {
            case 6:

                Destroy(FindObjectOfType<JammoPuzzleTwoAI>());
                FindObjectOfType<JammoDialogueTrigger>().enabled = true;
                Destroy(this);
                break;
            case 5:
                currentDest = new Vector3(-77.7f, 4.5f, -41.56f);
                break;
            case 4:
                currentDest = new Vector3(-65f, 4.5f, -31.31f);
                break;
            case 3:
                currentDest = new Vector3(-43.7f, 4.5f, -31.31f);
                break;
            case 2:
                currentDest = new Vector3(-36.76f, 4.5f, -26.4f);
                break;
            case 1:
                currentDest = new Vector3(-16.5f, 4.5f, -26.4f);

                break;


        }

        gameObject.transform.position = currentDest;

    }
}
