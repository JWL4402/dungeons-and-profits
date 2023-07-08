using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShelfSlotScript : MonoBehaviour
{
    [SerializeField] Image itemFrame;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI priceTag;
    [SerializeField] Slider priceSlider;

    [SerializeField] Item[] selection;
    public Item selected_item;
    int selection_index;
    int price;
    //#nullable enable
    //public Item? Item {
    //    get { return item; }
    //    set
    //    {
    //        item = value;
    //        UpdateAttributes();
    //    }
    //}
    //#nullable disable
    void Start()
    {
        if (selection.Length > 0)
        {
            selected_item = selection[0];
            price = selected_item.defaultPrice;
        }
        UpdateAttributes();
    }

    [ContextMenu("Update")]
    private void UpdateAttributes()
    {
        if (selected_item != null)
        {
            itemFrame.sprite = selected_item.sprite;
            itemName.text = selected_item.name;
            priceTag.text = price.ToString() + '$';
            priceSlider.minValue = selected_item.minPrice;
            priceSlider.maxValue = selected_item.maxPrice;
            priceSlider.value = selected_item.defaultPrice;

            priceSlider.onValueChanged.AddListener((price) => SetPrice((int) price));

        }
    }

    public void SetPrice(int newPrice)
    {
        price = newPrice;
        UpdateAttributes();
    }

    public void AddPrice(int priceChange)
    {
        price += priceChange;
        UpdateAttributes();
    }
}
