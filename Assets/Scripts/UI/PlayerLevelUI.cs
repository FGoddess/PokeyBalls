using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] private Text _currentLevelText;
    [SerializeField] private Image _currentLevelImage;

    [SerializeField] private Text _nextLevelText;
    [SerializeField] private Image _nextLevelImage;

    [SerializeField] private Transform _ball;
    private Transform _finish;

    private void Start()
    {
        var playerLevel = SavesManager.Instance.GetPlayerLevel();
        _currentLevelText.text = playerLevel.ToString();
        _nextLevelText.text = (playerLevel + 1).ToString();
    }

    public void Initialize(Transform finish)
    {
        _finish = finish;

        _slider.maxValue = GetDistance(_ball.position.y, _finish.position.y);
    }

    private void Update()
    {
        if (_finish == null) return;

        _slider.value = _slider.maxValue - GetDistance(_ball.position.y, _finish.position.y);

        if (_slider.value == _slider.maxValue)
        {
            OnFinishReached();
        }
    }

    private float GetDistance(float startPoint, float destinationPoint)
    {
        return destinationPoint - startPoint;
    }

    private void OnFinishReached()
    {
        _nextLevelImage.color = _currentLevelImage.color;
        _finish = null;
        SavesManager.Instance.SaveLevelData();
    }
}
