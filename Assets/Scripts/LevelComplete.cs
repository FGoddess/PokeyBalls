using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class LevelComplete : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    private float _levelLoadDelay = 1f;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
    }

    private void OnEnable()
    {
        _ball.FinishBlockHitted += OnLevelComplete;
    }

    private void OnDisable()
    {
        _ball.FinishBlockHitted -= OnLevelComplete;
    }

    public void OnLevelComplete()
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        var playerLevel = PlayerPrefs.GetInt("PlayerLevel", 0);
        PlayerPrefs.SetInt("PlayerLevel", ++playerLevel);

        var towerId = PlayerPrefs.GetInt("TowerId", 0);
        //PlayerPrefs.SetInt("TowerId", ++towerId);

        StartCoroutine(LoadNextLevel());
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(_levelLoadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
