using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfSlotScript : MonoBehaviour
{
    [SerializeField] GameObject itemFrame;

    [SerializeField] Item item;
    #nullable enable
    public Item? Item {
        get { return item; }
        set
        {
            item = value;
            UpdateAttributes();
        }
    }
    #nullable disable
    void Start()
    {
        UpdateAttributes();
    }

    [ContextMenu("Update")]
    private void UpdateAttributes()
    {
        Debug.Log(true);
        if (item != null)
        {
            itemFrame.GetComponent<Image>().sprite = item.sprite;
        }
    }
}
