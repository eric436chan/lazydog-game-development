using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public bool isKeyItem = false;
    [TextArea(3, 5)]
    public string desc = "Description";

  
}
