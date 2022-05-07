using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsDisplay : MonoBehaviour
{
    [SerializeField] private List<Text> _coinsTexts;

    public void UpdateCoinsUI(int coins)
    {
        _coinsTexts.ForEach(text => text.text = coins.ToString() + "$");
    }
}
