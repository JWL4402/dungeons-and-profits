using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

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
        Debug.Log("Awake");
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