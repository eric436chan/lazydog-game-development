using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //GameObject selected = null;
    public Sprite[] sprites;
    private GameObject inventory_slot0;
    private GameObject inventory_slot1;
    private GameObject inventory_slot2;
    private GameObject inventory_slot3;
    private GameObject inventory_slot4;
    
    private Image child = null;


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

    #endregion Singleton

    public List<Item> inventory = new List<Item>();
    [SerializeField] private int inventorySpace = 5;

    private void Start()
    {
        LoadIcons();

        inventory_slot0 = GameObject.Find("inventory_slot0");
        inventory_slot1 = GameObject.Find("inventory_slot1");
        inventory_slot2 = GameObject.Find("inventory_slot2");
        inventory_slot3 = GameObject.Find("inventory_slot3");
        inventory_slot4 = GameObject.Find("inventory_slot4");
        //inventory_slot5 = GameObject.Find("inventory_slot5").GetComponent<Image>();
    }

    private void LoadIcons()
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
        if (inventory.Count < inventorySpace)
        {
            inventory.Add(item);
            updateInventoryItem(item.name);
        }
    }

    private void updateInventoryItem(string name)
    {
        switch (inventory.Count-1)
        {
            case 0:
                Debug.Log("Case 0");
                //gets the 0th child of the inventory slot, the icon
                child = inventory_slot0.transform.GetChild(0).GetComponent<Image>();
                break;

            case 1:
                Debug.Log("Case 1");
                child = inventory_slot1.transform.GetChild(0).GetComponent<Image>();
                break;

            case 2:
                Debug.Log("Case 2");
                child = inventory_slot2.transform.GetChild(0).GetComponent<Image>();
                break;

            case 3:
                Debug.Log("Case 3");
                child = inventory_slot3.transform.GetChild(0).GetComponent<Image>();
                break;

            case 4:
                Debug.Log("Case 4");
                child = inventory_slot4.transform.GetChild(0).GetComponent<Image>();
                break;

            default:
                Debug.Log("Empty");
                break;
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
        if (name.Contains("Saw"))
        {
            Debug.Log(sprites[1].ToString());
            child.sprite = sprites[1];

            Color temp = child.color;
            temp.a = 1f;
            child.color = temp;
        }
        if (name.Contains("Screwdriver"))
        {
            Debug.Log(sprites[5].ToString());
            child.sprite = sprites[5];

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