using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    GameObject selected = null;
    int current_num_of_items;

    List<Sprite> list_of_sprites;
    GameObject inventory_slot1;
    GameObject inventory_slot2;
    GameObject inventory_slot3;
    GameObject inventory_slot4;
    GameObject inventory_slot5;
    GameObject child = null;


    // Start is called before the first frame update
    void Start()
    {
        current_num_of_items = 0;
        inventory_slot1 = GameObject.Find("inventory_slot1");
        inventory_slot2 = GameObject.Find("inventory_slot2");
        inventory_slot3 = GameObject.Find("inventory_slot3");
        inventory_slot4 = GameObject.Find("inventory_slot4");
        inventory_slot5 = GameObject.Find("inventory_slot5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
