using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private CoinsDisplay _coinsDisplay;
    private int _coinsAmount;

    private void Awake()
    {
        _coinsAmount = SavesManager.Instance.GetCoins();
        _coinsDisplay.UpdateCoinsUI(_coinsAmount);
    }

    public void AddCoin()
    {
        _coinsAmount++;
        _coinsDisplay.UpdateCoinsUI(_coinsAmount);
        SavesManager.Instance.SetCoins(_coinsAmount);
    }
}
