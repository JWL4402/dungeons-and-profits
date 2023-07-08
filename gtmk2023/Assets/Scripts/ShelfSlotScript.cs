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
    [SerializeField] TextMeshProUGUI costTag;
    [SerializeField] Slider priceSlider;

    [SerializeField] Item[] selection;
    public Item selected_item;
    private Item last_item;
    int selection_index;
    int price;

    void Start()
    {
        if (selection.Length > 0)
        {
            selection_index = selection.Length;
            selected_item = selection[0];
        }
        UpdateAttributes();
    }

    [ContextMenu("Update")]
    private void UpdateAttributes()
    {
        if (selected_item != null)
        {
            if (selected_item != last_item)
            {
                priceSlider.onValueChanged.AddListener((price) => SetPrice((int)price));
                itemFrame.sprite = selected_item.sprite;
                itemName.text = selected_item.name;
                costTag.text = "Costs " + selected_item.cost + "g";
                priceSlider.minValue = selected_item.minPrice;
                priceSlider.maxValue = selected_item.maxPrice;
                price = selected_item.defaultPrice;

                last_item = selected_item;
            }

            if (price != priceSlider.value)
            {
                priceSlider.value = price;
            }

            priceTag.text = price.ToString() + 'g';
        }
    }

    public void SetPrice(int newPrice)
    {
        price = newPrice;
        UpdateAttributes();
    }

    public void AddPrice(int priceChange)
    {
        int newPrice = price + priceChange;
        if (newPrice > selected_item.maxPrice)
        {
            price = selected_item.maxPrice;
        }
        else if (newPrice < selected_item.minPrice)
        {
            price = selected_item.minPrice;
        }
        else
        {
            price += priceChange;
        }
        UpdateAttributes();
    }

    public void CycleItem(int change)
    {
        if (selection.Length <= 1) { return; }
        
        selection_index = selection.Length + ((selection_index + change) % selection.Length);

        selected_item = selection[selection_index  % selection.Length];
        UpdateAttributes();
    }
}
