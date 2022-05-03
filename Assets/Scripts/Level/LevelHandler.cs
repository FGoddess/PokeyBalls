using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class LevelHandler : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    private float _levelLoadDelay = 2f;

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
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        StartCoroutine(LoadNextLevel());
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(_levelLoadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
