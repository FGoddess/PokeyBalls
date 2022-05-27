using UnityEngine;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance { get; private set; }

    [SerializeField] private Ball _player;
    [SerializeField] private CoinsManager _coinsManager;

    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _reviveButton;
    [SerializeField] private Button _addMoneyButton;

    private YandexSDK _sdk;

    private bool _needUnmute;

    private const string KeyMoney = "300";
    private const string KEY_REVIVE = "revive";

    [SerializeField] private Text _debugText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _sdk = YandexSDK.instance;

        _sdk.onInterstitialShown += SdkNull;
        _sdk.onInterstitialFailed += SdkNull;

        _sdk.onRewardedAdReward += RevivePlayer;
        _sdk.onRewardedAdOpened += TryMuteAudio;
        _sdk.onRewardedAdClosed += TryUnmuteAudio;
        _sdk.onRewardedAdError += SdkNull;

        _sdk.onLanguageGet += SetLanguage;

        _shopButton.onClick.AddListener(() => _sdk.ShowInterstitial());
        _reviveButton.onClick.AddListener(() => _sdk.ShowRewarded(KEY_REVIVE));
        _addMoneyButton.onClick.AddListener(() => _sdk.ShowRewarded(KeyMoney));
    }

    private void SetLanguage(string lang)
    {
        _debugText.text = lang;
    }

    private void TryUnmuteAudio(int value)
    {
        if (!_needUnmute) return;
        _needUnmute = false;
        AudioPlayer.Instance.Mute();
    }

    private void TryMuteAudio(int value)
    {
        if (AudioPlayer.Instance.IsMuted) return;
        _needUnmute = true;
        AudioPlayer.Instance.Mute();
    }

    private void RevivePlayer(string str)
    {
        switch (str)
        {
            case KEY_REVIVE:
                _player.Revive();
                break;
            case KeyMoney:
                _coinsManager.AddCoins(int.Parse(KeyMoney));
                break;
        }
    }

    public void TryShowInterstitialAd()
    {
        _sdk.ShowInterstitial();
    }

    private void SdkNull(string obj) { }

    private void SdkNull() { }
}
