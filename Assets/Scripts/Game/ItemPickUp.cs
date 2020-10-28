using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    Camera cam;
    RaycastHit hit;
    GameObject selected = null;

    private void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        if (selected != null)
        {
            selected.GetComponent<MeshRenderer>().material.SetFloat("Boolean_Focused", 0f);
            selected = null;
        }

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("Key Item"))
            {
                selected = hit.transform.gameObject;
                selected.GetComponent<MeshRenderer>().material.SetFloat("Boolean_Focused", 1f);


                if (Input.GetKeyDown(KeyCode.E))
                {
                    Inventory.instance.addItem(selected.GetComponent<PickUpItem>().item);
                    Destroy(hit.transform.gameObject);
                    selected = null;
                }
            }
        }
    }
}

