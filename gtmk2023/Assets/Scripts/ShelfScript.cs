using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShelfScript : MonoBehaviour
{
    public int items;
    [SerializeField]
    private GameObject template;
    private GameObject[] displayed_items;
    
    void InitializeItems(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newItem = GameObject.Instantiate(template, Vector3.zero, Quaternion.identity, gameObject.transform);
            newItem.GetComponent<ShelfSlotScript>().selected_item = null;
            displayed_items.Append(newItem);
        }
    }

    void Start()
    {
        displayed_items = new GameObject[items];
        InitializeItems(items);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
