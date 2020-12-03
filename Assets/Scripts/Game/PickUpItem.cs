using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public Item item;

    private void OnMouseOver()
    {
        foreach (Material m in gameObject.GetComponent<MeshRenderer>().materials)
        {
            m.SetFloat("Boolean_Focused", 1f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Inventory.instance.addItem(item);
            Destroy(gameObject);
        }
    }

    private void OnMouseExit()
    {
        foreach (Material m in gameObject.GetComponent<MeshRenderer>().materials)
        {
            m.SetFloat("Boolean_Focused", 0f);
        }
    }
}