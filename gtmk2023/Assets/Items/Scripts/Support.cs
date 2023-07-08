using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New support", menuName = "Items/Support")]
public class Support : Item
{
    public float speed;
    public float defense;
    public float bonus_damage;
    public float spellEfficiency;
}