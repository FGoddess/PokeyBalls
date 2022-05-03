using UnityEngine;

public class UIState : MonoBehaviour
{
    [SerializeField] private Swipe _swipe;

    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private GameObject _menuUI;

    private void Awake()
    {
        _inGameUI.SetActive(false);
    }

    private void OnEnable()
    {
        _swipe.DragEnded += ChangeState;
    }

    private void ChangeState()
    {
        _inGameUI.SetActive(true);
        _menuUI.SetActive(false);

        _swipe.DragEnded -= ChangeState;
    }
}
