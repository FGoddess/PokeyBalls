using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopItem[] _items;

    private void Start()
    {
        UpdateItems();
    }

    public void UpdateItems()
    {
        foreach(var item in _items)
        {
            item.Button.onClick.RemoveAllListeners();
            item.Reload();
        }
    }
}
