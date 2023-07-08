using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public int damage;
    public int speed;

    override public void ApplyEffects(Party party, int amount)
    {
        party.damage += damage * amount;
        party.speed += speed * amount;
    }
}