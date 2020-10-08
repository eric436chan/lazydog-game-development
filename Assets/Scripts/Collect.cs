using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collect : MonoBehaviour
{
    public CharacterController controller;
    public float dist;
    public Item item;
    float delay = 0.25f;
    float timeSincePressed = 0f;

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.tag.Equals("Player"))
    //    {
    //        Inventory.instance.addItem(item);
    //        Debug.Log("Collecting " + item.name);
    //        Destroy(gameObject);
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag.Equals("Player"))
    //    {
    //        Inventory.instance.addItem(item);
    //        Debug.Log("Collecting " + item.name);
    //        Destroy(gameObject);
    //    }
    //}


    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(gameObject.transform.position, controller.transform.position);



        if (dist <= 2.5f && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.instance.addItem(item);
            Debug.Log("Collecting " + item.name);
            Destroy(gameObject);
        }

    }
}
