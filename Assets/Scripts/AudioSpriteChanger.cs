using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Button))]
public class AudioSpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private Button _button;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();

        AudioPlayer.Instance.VolumeStateChanged += ChangeSprite;

        _button.onClick.AddListener(() => AudioPlayer.Instance.Mute());

        ChangeSprite(AudioPlayer.Instance.IsMuted);
    }

    private void OnDestroy()
    {
        AudioPlayer.Instance.VolumeStateChanged -= ChangeSprite;
        _button.onClick.RemoveAllListeners();
    }

    private void ChangeSprite(bool value)
    {
        _image.sprite = value ? _soundOff : _soundOn;
    }
}
