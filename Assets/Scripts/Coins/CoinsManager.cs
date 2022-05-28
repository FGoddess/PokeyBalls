using System;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private CoinsDisplay _coinsDisplay;
    [SerializeField] private Ball _ball;

    public int CoinsAmount { get; private set; }

    private const int COINSTOSAVE = 5;
    private int _coinsCounter;

    private void Start()
    {
        CoinsAmount = SavesManager.Instance.GetCoins();
        UpdateCoins();
    }

    private void OnEnable()
    {
        _ball.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _ball.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        SavesManager.Instance.SetCoins(CoinsAmount);
    }

    public void AddOneCoin()
    {
        CoinsAmount++;
        _coinsCounter++;
        
        if (_coinsCounter == COINSTOSAVE)
        {
            UpdateCoins();
            _coinsCounter = 0;
            return;
        }
        
        _coinsDisplay.UpdateCoinsUI(CoinsAmount);
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
