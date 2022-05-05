using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkinActivator : MonoBehaviour
{
    public static SkinActivator Instance { get; private set; }

    [SerializeField] private List<PlayerSkin> _skins;
    [SerializeField] private CoinsManager _coinsManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSkin(PlayerSkin skin)
    {
        Debug.Log(skin.name);
        _skins.ForEach(s => { s.gameObject.SetActive(false); s.UnEquip(); }) ;
        var temp = _skins.FirstOrDefault(s => s == skin);
        temp.gameObject.SetActive(true);
        temp.Equip();
    }

    public void TryBuySkin(PlayerSkin skin)
    {
        if(_coinsManager.CoinsAmount >= skin.Price)
        {
            _coinsManager.WithdrawCoins(skin.Price);
            _skins.ForEach(s => { s.gameObject.SetActive(false); s.UnEquip(); });
            _skins.FirstOrDefault(s => s == skin).gameObject.SetActive(true);
            skin.Purchase();
            skin.Equip();
        }
    }
}
