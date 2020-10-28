using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

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

    public void addItem(Item item)
    {
        if (inventory.Count < inventorySpace)
        {
            inventory.Add(item);
            Debug.Log(item.name);
        }
    }

    public void clearInventory()
    {
        inventory.Clear();
    }

}
