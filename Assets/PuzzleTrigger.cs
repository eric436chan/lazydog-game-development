using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{

    public CharacterController controller;
    public GameObject puzzle;
    InteractableObjectImpl highlightScript;
    //Focus focusScript;
    MeshRenderer mesh;
    public float dist;

    private void Start()
    {
        highlightScript = gameObject.GetComponent<InteractableObjectImpl>();
        //focusScript = controller.gameObject.GetComponent<Focus>();
        mesh = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

       
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);

        if(dist <= 5f && Input.GetKeyDown(KeyCode.E))
        {
            puzzle.SetActive(false);
            //focusScript.enabled = false;
            mesh.material.SetFloat("Boolean_Focused", 0f);
            Destroy(highlightScript);
        }

        //focusScript.enabled = true;


    }
}
