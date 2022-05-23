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

    private readonly string KEY_MONEY = "300";
    private readonly string KEY_REVIVE = "revive";

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

        _shopButton.onClick.AddListener(() => _sdk.ShowInterstitial());
        _reviveButton.onClick.AddListener(() => _sdk.ShowRewarded(KEY_REVIVE));
        _addMoneyButton.onClick.AddListener(() => _sdk.ShowRewarded(KEY_MONEY));
    }

    private void TryUnmuteAudio(int value)
    {
        if (_needUnmute)
        {
            _needUnmute = false;
            AudioPlayer.Instance.Mute();
        }
    }

    private void TryMuteAudio(int value)
    {
        if (!AudioPlayer.Instance.IsMuted)
        {
            _needUnmute = true;
            AudioPlayer.Instance.Mute();
        }
    }

    private void RevivePlayer(string str)
    {
        if (str == KEY_REVIVE)
        {
            _player.Revive();
        }
        else if (str == KEY_MONEY)
        {
            _coinsManager.AddCoins(int.Parse(KEY_MONEY));
        }
    }

    public void TryShowInterstitialAd()
    {
        _sdk.ShowInterstitial();
    }

    private void SdkNull(string obj)
    {

    }

    private void SdkNull()
    {

    }
}
