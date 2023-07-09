using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using System.Reflection;

[CreateAssetMenu(fileName = "Party", menuName = "Items/Party")]
public class Party : ScriptableObject
{
    public int gold;
    public int health;

    public int initMaxHealth;
    public int initDamage;
    public int initBonusDamage;
    public int initSpeed;
    public int initDefense;
    public int initSpellEfficiency;

    public int damage;
    public int speed;
    public int defense;
    public int maxHealth;
    public int bonusDamage;
    public int spellEfficiency;

    public Dictionary<Item, int> inventory;

    public void Init()
    {
        inventory = new Dictionary<Item, int>();

        InitializeStats();
    }

    public void AddItem(Item item, int amount)
    {
        if (!inventory.TryAdd(item, amount))
        {
            inventory[item] += amount;
        }
        UpdateStats();
    }

    public void RemoveItem(Item item, int amount)
    {
        int inventoryAmount;
        if (!inventory.TryGetValue(item, out inventoryAmount))
        {
            Debug.Log("That item is not in the inventory?");
            return;
        }

        int newAmount = inventoryAmount - amount;
        if (newAmount <= 0)
        {
            inventory.Remove(item);
        }
        else
        {
            inventory[item] = newAmount;
        }
        UpdateStats();
    }

    public Dictionary<T, int> GetItemsOfType<T>() where T : Item
    {
        // coped from stack overflow
        //MethodInfo method = typeof(Queryable).GetMethod("OfType");
        //MethodInfo generic = method.MakeGenericMethod(new Type[] { type });
        //var result = (IEnumerable<object>)generic.Invoke
        //      (null, new object[] { inventory.Keys });
        //var typedKeys = result.ToArray() as type[];
        // thank you Jon Skeet

        //Dictionary<T, int> dict =
        //    inventory.Keys.Select(
        //        (weapon, amount) => new { weapon, amount }).ToDictionary(x => x.weapon as T, x => inventory[x.weapon]);
        //return dict;

        return inventory.Keys.OfType<T>().Select(
                (weapon, amount) => new { weapon, amount }).ToDictionary(x => x.weapon as T, x => inventory[x.weapon as T]);
        // THIS IS CRAZY BRO
    }

    private void InitializeStats()
    {
        damage = initDamage;
        speed = initSpeed;
        defense = initDefense;
        maxHealth = initMaxHealth;
        health = maxHealth;
        bonusDamage = initBonusDamage;
        spellEfficiency = initSpellEfficiency;
    }

    public void UpdateStats()
    {
        InitializeStats();
        if (inventory.Count == 0) { return; }
        foreach (var (item, amount) in inventory)
        {
            item.ApplyEffects(this, amount);
        }
    }
}