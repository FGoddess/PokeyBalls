using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private PlayerSkin _skin;
    private Shop _shop;

    private string _purchasedText;
    private string _equippedText;

    [field: SerializeField]
    public Image Image { get; set; }

    [field: SerializeField]
    public Button Button { get; set; }

    [field: SerializeField]
    public Text ButtonText { get; set; }

    public bool IsEquipped => _skin.IsEquppied;

    public void Initialize()
    {
        _shop = GetComponentInParent<Shop>();

        _equippedText = "X";
        _purchasedText = "X";

        _skin.CheckSaves();
    }

    public void Reload()
    {
        if (_skin.IsEquppied)
        {
            Equip();
            ButtonText.color = Color.green;
            return;
        }

        if (_skin.IsPurchased)
        {
            ButtonText.text = _purchasedText;
            ButtonText.color = Color.grey;
            Button.onClick.AddListener(() => SetSkin());
            return;
        }

        ButtonText.text = $"{_skin.Price}$";
        ButtonText.color = Color.white;
        Button.onClick.AddListener(() => BuySkin());
    }

    public void Equip()
    {
        SkinActivator.Instance.SetSkin(_skin);
        ButtonText.text = _equippedText;
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
