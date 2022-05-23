using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [field: SerializeField]
    public bool IsEquppied { get; private set; }

    [field: SerializeField]
    public bool IsPurchased { get; private set; }

    [field: SerializeField]
    public int Price { get; private set; }

    public void CheckSaves()
    {
        IsEquppied = PlayerPrefsExtension.HasKey($"{name}IsEquipped");

        if(!IsPurchased)
        {
            IsPurchased = PlayerPrefsExtension.HasKey($"{name}IsPurchased");
        }
    }

    public void Equip()
    {
        PlayerPrefsExtension.SetString($"{name}IsEquipped", "true");
        IsEquppied = true;
    }

    public void UnEquip()
    {
        PlayerPrefsExtension.DeleteKey($"{name}IsEquipped");
        IsEquppied = false;
    }

    public void Purchase()
    {
        PlayerPrefsExtension.SetString($"{name}IsPurchased", "true");
        IsPurchased = true;
    }
}
