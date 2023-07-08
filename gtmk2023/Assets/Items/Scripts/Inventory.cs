using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Items/Inventory")]
public class Inventory : ScriptableObject
{
    public Dictionary<Item, int> stock = new Dictionary<Item, int>();
    [ContextMenu("Print")]
    void print()
    {
        {
            foreach (KeyValuePair<Item, int> kvp in stock)
                Debug.Log("Key = " + kvp.Key.name + ", Value = " + kvp.Value + ',');
        }
    }
}