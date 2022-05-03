using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSFX : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => AudioPlayer.Instance.PlayButtonClickSFX());
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }
}
