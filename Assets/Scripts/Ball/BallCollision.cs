using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private CoinsManager _coinsManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            _coinsManager.AddCoin();
        }
    }
}
