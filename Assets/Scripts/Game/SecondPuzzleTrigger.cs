using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPuzzleTrigger : MonoBehaviour
{
    public CharacterController controller;
    float dist;
    public GameObject puzzle;
    InteractableObjectImpl highlightScript;


    private void Start()
    {
        highlightScript = gameObject.GetComponent<InteractableObjectImpl>();
    }
    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(controller.transform.position, gameObject.transform.position);

        if(dist <= 5f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PuzzleManager.instance.puzzleTwoFixed++;
                highlightScript.SetLevel(99);
                puzzle.SetActive(false);
                Destroy(this);
            }
        }


    }
}
