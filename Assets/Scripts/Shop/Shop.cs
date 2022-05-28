using UnityEngine;
using YG;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopItem[] _items;

    private void Start()
    {
        foreach (var item in _items)
        {
            item.Initialize();
        }

        UpdateItems();

        foreach (var item in _items)
        {
            if (item.IsEquipped)
            {
                return;
            }
        }

        _items[0].Equip();
    }

    public void UpdateItems()
    {
        foreach (var item in _items)
        {
            item.Button.onClick.RemoveAllListeners();
            item.Reload();
        }
    }
}
