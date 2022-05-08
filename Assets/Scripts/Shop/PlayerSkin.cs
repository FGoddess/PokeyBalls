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
        //IsEqupied = PlayerPrefsExtension.HasKey($"{name}IsEquiped");
        IsEquppied = PlayerPrefs.HasKey($"{name}IsEquiped");

        //IsPurchased = PlayerPrefsExtension.HasKey($"{name}IsPurchased") || name == "Skin 1";

        if(!IsPurchased)
        {
            IsPurchased = PlayerPrefs.HasKey($"{name}IsPurchased");
        }
    }

    public void Equip()
    {
        //PlayerPrefsExtension.SetString($"{name}IsEquiped", "true");
        PlayerPrefs.SetString($"{name}IsEquiped", "true");
        IsEquppied = true;
    }

    public void UnEquip()
    {
        //PlayerPrefsExtension.DeleteKey($"{name}IsEquiped");
        PlayerPrefs.DeleteKey($"{name}IsEquiped");
        IsEquppied = false;
    }

    public void Purchase()
    {
        //PlayerPrefsExtension.SetString($"{name}IsPurchased", "true");
        PlayerPrefs.SetString($"{name}IsPurchased", "true");
        IsPurchased = true;
    }
}
