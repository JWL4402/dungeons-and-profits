using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShelfItemScript : MonoBehaviour
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
            displayed_items.Append(newItem);
            
            //GameObject newItem = new GameObject();
            //items.Append(newItem);

            //Image newImage = newItem.AddComponent<Image>();
            //newImage.color = items[0].GetComponent<Image>().color;

            //RectTransform newRect = newItem.GetComponent<RectTransform>();
            //newRect.SetParent(gameObject.transform);
            //newRect.transform.localScale = Vector3.one;

            //newItem.SetActive(true);
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
