using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance { get; private set; }

    [SerializeField] private AudioClip[] _music;

    [SerializeField] private AudioClip _throwSFX;
    [SerializeField] private AudioClip _winSFX;
    [SerializeField] private AudioClip _deathSFX;
    [SerializeField] private AudioClip _buttonClickSFX;

    public bool IsMuted => _audioSource.mute;

    private AudioSource _audioSource;

    public event Action<bool> VolumeStateChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = _music[UnityEngine.Random.Range(0, _music.Length)];
            _audioSource.Play();
        }
    }

    public void PlayThrowSFX()
    {
        _audioSource.PlayOneShot(_throwSFX);
    }

    public void PlayDeathSFX()
    {
        _audioSource.PlayOneShot(_deathSFX);
    }

    public void PlayWinSFX()
    {
        _audioSource.PlayOneShot(_winSFX);
    }

    public void PlayButtonClickSFX()
    {
        _audioSource.PlayOneShot(_buttonClickSFX);
    }

    public void Mute()
    {
        _audioSource.mute = !_audioSource.mute;
        VolumeStateChanged?.Invoke(_audioSource.mute);
    }
}
