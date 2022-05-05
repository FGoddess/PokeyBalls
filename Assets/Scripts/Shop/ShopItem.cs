using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private PlayerSkin _skin;
    private Shop _shop;

    [field: SerializeField]
    public Image Image { get; set; }

    [field: SerializeField]
    public Button Button { get; set; }

    [field: SerializeField]
    public Text ButtonText { get; set; }

    private void Awake()
    {
        _shop = GetComponentInParent<Shop>();
    }

    public void Reload()
    {
        if (_skin.IsEqupied)
        {
            SkinActivator.Instance.SetSkin(_skin);
            ButtonText.text = "Выбрано";
            return;
        }

        if (_skin.IsPurchased)
        {
            ButtonText.text = "Выбрать";
            Button.onClick.AddListener(() => SetSkin());
            return;
        }

        ButtonText.text = $"{_skin.Price}$";
        Button.onClick.AddListener(() => BuySkin());
    }

    private void SetSkin()
    {
        SkinActivator.Instance.SetSkin(_skin);
        _shop.UpdateItems();
    }

    private void BuySkin()
    {
        SkinActivator.Instance.TryBuySkin(_skin);
        _shop.UpdateItems();
    }

    private void OnDestroy()
    {
        Button.onClick.RemoveAllListeners();
    }
}
