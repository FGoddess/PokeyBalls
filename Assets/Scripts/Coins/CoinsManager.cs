using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private CoinsDisplay _coinsDisplay;
    private int _coinsAmount;

    private void Start()
    {
        _coinsAmount = SavesManager.Instance.GetCoins();
        UpdateCoins();
    }

    public void AddOneCoin()
    {
        _coinsAmount++;
        UpdateCoins();
    }

    public void AddCoins(int value)
    {
        _coinsAmount += value;
        UpdateCoins();
    }

    private void UpdateCoins()
    {
        _coinsDisplay.UpdateCoinsUI(_coinsAmount);
        SavesManager.Instance.SetCoins(_coinsAmount);
    }
}
