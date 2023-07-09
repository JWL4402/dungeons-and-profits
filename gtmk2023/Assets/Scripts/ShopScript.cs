using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public Party adventurers;

    public GameObject shopShelf;
    public GameObject purchase;
    public TextMeshProUGUI purchaseLog;
    public Dictionary<Item, int> displayedItems;

    public Item[] items;

    public void MoveToPurchasing()
    {
        displayedItems = new Dictionary<Item, int>();
        
        ShelfSlotScript[] slots = shopShelf.GetComponentsInChildren<ShelfSlotScript>();
        foreach (var slot in slots) { Debug.Log(slot.selected_item); }

        foreach(ShelfSlotScript slot in slots)
        {
            if (slot.selected_item != null)
            {
                displayedItems.Add(slot.selected_item, slot.price);
            }
            Debug.Log(slot.selected_item);
            Debug.Log(slot.price);
        }

        shopShelf.SetActive(false);
        purchase.SetActive(true);
        PurchaseItems();
    }

    public bool PurchaseItemOfType<T>()
    {
        T item = displayedItems.Keys.OfType<T>().ToArray()[0];
        if (adventurers.gold >= displayedItems[item as Item])
        {
            if (!adventurers.inventory.TryAdd(item as Item, 1))
            {
                adventurers.inventory[item as Item]++;
            }
            adventurers.gold -= displayedItems[item as Item];
            purchaseLog.text += "Adventurers bought " + (item as Item).name + " for " + displayedItems[item as Item] + " gold.\n";
            
            return true;
        }
        return false;
    }

    [ContextMenu("Purchase")]
    public void PurchaseItems()
    {
        adventurers.UpdateStats();
        Dictionary<string, float> weights = new Dictionary<string, float>
        {
            { "damage", adventurers.damage * 0.8f },
            { "defense", adventurers.defense * 0.8f },
            //{ "speed", adventurers.speed * 0.25f}
        };

        var sortedDict = from entry in weights orderby entry.Value ascending select entry;

        while (adventurers.gold > 50 && weights.Count != 0)
        {
            string category = weights.Keys.ToArray()[0];
            Debug.Log(category);
            if (category == "damage")
            {
                PurchaseItemOfType<Weapon>();
            }
            else if (category == "defense")
            {
                PurchaseItemOfType<Support>();
            }
            //else if (category == "speed")
            //{
            //    PurchaseItemOfType<>
            //}
            weights.Remove(category);
        }

        //int potions = adventurers.GetItemsOfType<Potion>().Values.Sum();

        //while (potions < 10)
        //{
        //    if (!PurchaseItemOfType<Potion>())
        //    {
        //        break;
        //    }
        //}

        //PurchaseItemOfType<Consumable>();
        //PurchaseItemOfType<Spell>();

        //Dictionary<Weapon, int> invWeapons = adventurers.GetItemsOfType<Weapon>();
        //Dictionary<Consumable, int> invConsumables = adventurers.GetItemsOfType<Consumable>();
        
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
