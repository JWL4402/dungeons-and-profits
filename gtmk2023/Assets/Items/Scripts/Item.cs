using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    new public string name = "New item";
    public Sprite sprite;
}