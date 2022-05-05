using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [field: SerializeField]
    public bool IsEqupied { get; private set; }

    [field: SerializeField]
    public bool IsPurchased { get; private set; }

    [field: SerializeField]
    public int Price { get; private set; }

    public void CheckSaves()
    {
        //IsEqupied = PlayerPrefsExtension.HasKey($"{name}IsEquiped");

        //IsPurchased = PlayerPrefsExtension.HasKey($"{name}IsPurchased") || name == "Skin 1";
    }

    public void Equip()
    {
        //PlayerPrefsExtension.SetString($"{name}IsEquiped", "true");
        IsEqupied = true;
    }

    public void UnEquip()
    {
        //PlayerPrefsExtension.DeleteKey($"{name}IsEquiped");
        IsEqupied = false;
    }

    public void Purchase()
    {
        //PlayerPrefsExtension.SetString($"{name}IsPurchased", "true");
        IsPurchased = true;
    }
}
