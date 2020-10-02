using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{

    MeshRenderer renderer;
    public CharacterController controller;

    void Start()
    {

        renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material.SetFloat("Boolean_A02DFE45", 0f);
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(controller.transform.position, gameObject.transform.position) < 7.5f)
        {
            renderer.material.SetFloat("Boolean_A02DFE45", 1f);
        }
        else
        {
            renderer.material.SetFloat("Boolean_A02DFE45", 0f);
        }

    }

    private void OnMouseExit()
    {
        renderer.material.SetFloat("Boolean_A02DFE45", 0f);
    }
}
