using UnityEngine;
using UnityEngine.UI;

public class CoinsDisplay : MonoBehaviour
{
    [SerializeField] private Text _coinsText;

    public void UpdateCoinsUI(int coins)
    {
        _coinsText.text = coins.ToString();
    }
}
