using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class Swipe : MonoBehaviour, IEndDragHandler, IDragHandler, IPointerDownHandler
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Pole _pole;

    private CanvasGroup _canvasGroup;

    private const float _minDifference = 0.35f;

    private float _minY;
    private float _maxY;

    private float _bendMultiplier = 10f;
    private float _deltaDivider = 1000f;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
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
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _maxY = _ball.transform.position.y;
        _minY = _maxY - _minDifference;

        _ball.TryFix();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.y) > Mathf.Abs(eventData.delta.x) && _ball.IsFixed)
        {
            var pos = _ball.transform.position;
            var poleDelta = _pole.Curvature;

            pos.y += eventData.delta.y / _deltaDivider;
            poleDelta -= eventData.delta.y / _deltaDivider * _bendMultiplier;

            _ball.transform.position = new Vector3(pos.x, Mathf.Clamp(pos.y, _minY, _maxY), pos.z);
            _pole.Curvature = Mathf.Clamp(poleDelta, 0f, _minDifference * _bendMultiplier);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _ball.TryThrow(_pole.Curvature);
        _pole.ResetBend();
    }
}
