using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    private float _deathScreenDelay = 1f;
    private float _lerpDuration = 1f;

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
        _ball.Revived += OnPlayerRevived;
    }

    private void OnDisable()
    {
        _ball.Died -= OnPlayerDeath;
        _ball.Revived -= OnPlayerRevived;
    }

    private void OnPlayerRevived()
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.alpha = 0f;
    }

    private void OnPlayerDeath()
    {
        StartCoroutine(ShowDeathScreen(0f, 1f));
    }

    private IEnumerator ShowDeathScreen(float startValue, float endValue)
    {
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = false;
        yield return new WaitForSeconds(_deathScreenDelay);

        float timeElapsed = 0;

        while (timeElapsed < _lerpDuration)
        {
            _canvasGroup.alpha = Mathf.Lerp(startValue, endValue, timeElapsed / _lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        AdsManager.Instance.TryShowInterstitialAd();
        _canvasGroup.alpha = endValue;
        _canvasGroup.interactable = true;
    }
}
