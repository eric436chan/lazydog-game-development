using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Focus : MonoBehaviour
{
    IEnumerable<InteractableObject> intObjList;
    // Update is called once per frame
    void Update()
    {

        intObjList = FindObjectsOfType<MonoBehaviour>().OfType<InteractableObject>();

        if (Input.GetKey(KeyCode.Z))
        {

            foreach (InteractableObject o in intObjList)
            {
                if (o.GetLevel() <= FocusLevel.instance.GetFocusLevel())
                {
                    o.GetMeshRenderer().material.SetFloat("", 1f);
                }
            }
        }
        else
        {
            foreach (InteractableObject o in intObjList)
            {
                o.GetMeshRenderer().material.SetFloat("", 0f);
            }
        }
    }
}
