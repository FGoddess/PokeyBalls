using System;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallCollision : MonoBehaviour
{
    [SerializeField] private CoinsManager _coinsManager;
    [SerializeField] private Ball _ball;

    private void Awake()
    {
        _ball = GetComponent<Ball>();
    }

    private void OnEnable()
    {
        _ball.FinishBlockHitted += OnFinishBlockHitted;
    }

    private void OnDisable()
    {
        _ball.FinishBlockHitted -= OnFinishBlockHitted;
    }

    private void OnFinishBlockHitted(int value)
    {
        _coinsManager.AddCoins(value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            _coinsManager.AddOneCoin();
        }
        else if (other.TryGetComponent(out DeathPlatform platform))
        {
            _ball.Die();
        }
    }
}
