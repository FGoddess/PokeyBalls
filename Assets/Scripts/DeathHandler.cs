using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    private float _deathScreenDelay = 1.5f;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnEnable()
    {
        _ball.Died += OnPlayerDeath;
    }

    private void OnDisable()
    {
        _ball.Died -= OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        StartCoroutine(ShowDeathScreen());
    }

    private IEnumerator ShowDeathScreen()
    {
        yield return new WaitForSeconds(_deathScreenDelay);
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }
}
