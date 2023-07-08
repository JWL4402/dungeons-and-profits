using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New support", menuName = "Items/Support")]
public class Support : Item
{
    public int speed;
    public int defense;
    public int bonusDamage;
    public int spellEfficiency;

    public override void ApplyEffects(Party party, int amount)
    {
        party.speed += speed * amount;
        party.defense += defense * amount;
        party.bonusDamage += bonusDamage * amount;
        party.spellEfficiency += spellEfficiency * amount;
    }
}