using Lean.Localization;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopItem[] _items;

    [SerializeField] private LeanLocalization _localization;

    private void Start()
    {
        foreach (var item in _items)
        {
            item.Initialize(_localization.CurrentLanguage);
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
