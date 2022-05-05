using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private CoinsDisplay _coinsDisplay;

    public int CoinsAmount { get; private set; }

    private void Start()
    {
        CoinsAmount = SavesManager.Instance.GetCoins();
        UpdateCoins();
    }

    public void AddOneCoin()
    {
        CoinsAmount++;
        UpdateCoins();
    }

    public void AddCoins(int value)
    {
        CoinsAmount += value;
        UpdateCoins();
    }

    public void WithdrawCoins(int value)
    {
        CoinsAmount -= value;
        UpdateCoins();
    }

    private void UpdateCoins()
    {
        _coinsDisplay.UpdateCoinsUI(CoinsAmount);
        SavesManager.Instance.SetCoins(CoinsAmount);
    }
}
