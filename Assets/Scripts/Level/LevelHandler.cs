using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class LevelHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    private float _levelLoadDelay = 3f;
    private float _particleDelay = 1f;

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
        _ball.GameWon += OnLevelComplete;
    }

    private void OnDisable()
    {
        _ball.GameWon -= OnLevelComplete;
    }

    public void OnLevelComplete()
    {
        StartCoroutine(FadeIn(0f, 1f));
    }

    private IEnumerator FadeIn(float startValue, float endValue)
    {
        _canvasGroup.blocksRaycasts = true;
        yield return new WaitForSeconds(_particleDelay);

        float timeElapsed = 0;

        while (timeElapsed < _lerpDuration)
        {
            _canvasGroup.alpha = Mathf.Lerp(startValue, endValue, timeElapsed / _lerpDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        _canvasGroup.alpha = endValue;
        yield return new WaitForSeconds(_levelLoadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
