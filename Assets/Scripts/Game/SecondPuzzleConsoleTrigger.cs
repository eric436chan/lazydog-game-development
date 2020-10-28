using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPuzzleConsoleTrigger : MonoBehaviour
{

    public CharacterController controller;
    float dist;
    //public GameObject puzzle;
    
    void Update()
    {
        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);

        if(dist <= 5f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(PuzzleManager.instance.puzzleTwoFixed == 3)
                {
                    PuzzleManager.instance.isPuzzleTwoFinished = true;
                    Debug.Log("Second Puzzle Completed");
                    
                    
                }
                else
                {
                    Debug.Log("Not enough power...");
                }
            }
        }





    }
}
