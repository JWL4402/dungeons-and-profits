using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    new public string name = "New item";
    public Sprite sprite;
    public int cost;
    public int defaultPrice;
    public int minPrice;
    public int maxPrice;

    virtual public void ApplyEffects(Party party, int amount)
    {
        return;
    }
}