using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    Camera cam;
    RaycastHit hit;
    GameObject selected = null;
    int current_num_of_items;

    +List<Sprite> list_of_sprites;
    GameObject inventory_slot1;
    GameObject inventory_slot2;
    GameObject inventory_slot3;
    GameObject inventory_slot4;
    GameObject inventory_slot5;
    GameObject child = null;

    private void Start()
    {
        list_of_sprites = new List<Sprite>();
        cam = Camera.main;
        current_num_of_items = 0;
        inventory_slot1 = GameObject.Find("inventory_slot1");
        inventory_slot2 = GameObject.Find("inventory_slot2");
        inventory_slot3 = GameObject.Find("inventory_slot3");
        inventory_slot4 = GameObject.Find("inventory_slot4");
        inventory_slot5 = GameObject.Find("inventory_slot5");
    }

    void updateInventoryIcon()
    {
        if (selected.tag.Contains("wrench"){
            child.sprite = player_f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        GameObject child = null;
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


                if (Input.GetKeyDown(KeyCode.E) && current_num_of_items <= 5 )
                {
                    Inventory.instance.addItem(selected.GetComponent<PickUpItem>().item);
                    

                    switch (current_num_of_items)
                    {
                        case 0:
                            Console.WriteLine("Case 0");
      
                            //gets the 0th child of the inventory slot, the icon
                            child = inventory_slot1.transform.GetChild(0).gameObject;
                            current_num_of_items += 1;
                            break;
                        case 1:
                            Console.WriteLine("Case 1");
                            child = inventory_slot2.transform.GetChild(0).gameObject;
                            current_num_of_items += 1;
                            break;
                        case 2:
                            Console.WriteLine("Case 2");
                            child = inventory_slot3.transform.GetChild(0).gameObject;
                            current_num_of_items += 1;
                            break;
                        case 3:
                            Console.WriteLine("Case 3");
                            child = inventory_slot4.transform.GetChild(0).gameObject;
                            current_num_of_items += 1;
                            break;
                        case 4:
                            Console.WriteLine("Case 4");
                            child = inventory_slot5.transform.GetChild(0).gameObject;
                            current_num_of_items += 1;
                            break;
                        default:
                            Console.WriteLine("No item");
                            break;
                    }

                    if(child != null)
                    {
                        updateInventoryItem();
                    }

                    Destroy(hit.transform.gameObject);
                    selected = null;

                }
            }
        }
    }
}

