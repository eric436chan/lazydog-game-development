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

    [SerializeField] List<GameObject> inventory = new List<GameObject>();
    [SerializeField] int inventorySpace = 5;

    public void addGameObject(GameObject go)
    {
        if (inventory.Count < inventorySpace)
        {
            inventory.Add(go);
            Debug.Log(go.name);
        }
    }

    public void clearInventory()
    {
        inventory.Clear();
    }

}
