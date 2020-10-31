using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //GameObject selected = null;
    int current_num_of_items;

    Item item;

    public Sprite[] sprites;
    GameObject inventory_slot1;
    GameObject inventory_slot2;
    GameObject inventory_slot3;
    GameObject inventory_slot4;
    GameObject inventory_slot0;
    Image child = null;

    int inventory_slot;

    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion

    [SerializeField] List<Item> inventory = new List<Item>();
    [SerializeField] int inventorySpace = 5;


    void Start()
    {
        LoadIcons();
        current_num_of_items = 0;
        inventory_slot = 0;
        inventory_slot0 = GameObject.Find("inventory_slot1");
        inventory_slot1 = GameObject.Find("inventory_slot1");
        inventory_slot2 = GameObject.Find("inventory_slot2");
        inventory_slot3 = GameObject.Find("inventory_slot3");
        inventory_slot4 = GameObject.Find("inventory_slot4");
        //inventory_slot5 = GameObject.Find("inventory_slot5").GetComponent<Image>();
    }

    void LoadIcons()
    {
        object[] loadedIcons = Resources.LoadAll("icons", typeof(Sprite));
        sprites = new Sprite[loadedIcons.Length];
        //this
        for (int x = 0; x < loadedIcons.Length; x++)
        {
            sprites[x] = (Sprite)loadedIcons[x];
            Debug.Log(sprites[x].ToString());
        }

    }
    public void addItem(Item item)
    {
        this.item = item;
        if (inventory.Count < inventorySpace)
        {
            inventory.Add(item);
            updateInventoryItem(item.name);
        }
    }

    void updateInventoryItem(string name)
    {
        


        switch (current_num_of_items)
        {
            case 0:
                Debug.Log("Case 0");

                //gets the 0th child of the inventory slot, the icon
                child = inventory_slot0.transform.GetChild(0).GetComponent<Image>();
                inventory_slot = 0;
                
                break;
            case 1:
                Debug.Log("Case 1");
                child = inventory_slot1.transform.GetChild(0).GetComponent<Image>(); 
                inventory_slot = 1;
                //current_num_of_items += 1;
                break;
            case 2:
                Debug.Log("Case 2");
                inventory_slot = 2;
                child = inventory_slot2.transform.GetChild(0).GetComponent<Image>();
                //current_num_of_items += 1;
                break;
            case 3:
                Debug.Log("Case 3");
                inventory_slot = 3;
                child = inventory_slot3.transform.GetChild(0).GetComponent<Image>();
                //current_num_of_items += 1;
                break;
            case 4:
                Debug.Log("Case 4");
                inventory_slot = 4;
                child = inventory_slot4.transform.GetChild(0).GetComponent<Image>();
                //current_num_of_items += 1;
                break;
            default:
                Debug.Log("Empty");
                break;
            current_num_of_items += 1;
        }

        //Debug.Log("hi");
        if (name.Contains("Wrench"))
        {
            Debug.Log(sprites[8].ToString());
            child.sprite = sprites[8];

            Color temp = child.color;
            temp.a = 1f;
            child.color = temp;
        }
            //Debug.Log(sprites[i].ToString());
        
    }

    public void clearInventory()
    {
        inventory.Clear();
    }

}
