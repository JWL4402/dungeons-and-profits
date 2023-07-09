using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public Party adventurers;

    public GameObject shopShelf;
    public Dictionary<Item, int> displayedItems;

    public Item[] items;

    public void MoveToPurchasing()
    {
        ShelfSlotScript[] slots = shopShelf.GetComponentsInChildren<ShelfSlotScript>();

        foreach(ShelfSlotScript slot in slots)
        {
            if (slot.selected_item != null)
            {
                displayedItems.Add(slot.selected_item, slot.price);
            }
            //Debug.Log(slot.selected_item);
            //Debug.Log(slot.price);
        }
    }

    [ContextMenu("Purchase")]
    public void PurchaseItems()
    {
        //Dictionary<Weapon, int> invWeapons = 
        //    adventurers.inventory.Keys.OfType<Weapon>().Select(
        //        (weapon, amount) => new { weapon, amount }).ToDictionary(x => x.weapon, x => adventurers.inventory[x.weapon]);
        //        new { weapon, amount }).ToDictionary(
        //var dict = list.Select((s, i) => new { s, i }).ToDictionary(x => x.i, x => x.s);
        Dictionary<Weapon, int> invWeapons = adventurers.GetItemsOfType<Weapon>();
        foreach (var (weapon, amount) in invWeapons)
        {
            Debug.Log(weapon);
            Debug.Log(amount);
        }
    }

    public void Start()
    {
        adventurers.Init();
        foreach (Item item in items)
        {
            Debug.Log(item);
            adventurers.inventory.Add(item, 2);
        }
    }
}
