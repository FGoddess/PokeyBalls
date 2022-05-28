using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AdsManager : MonoBehaviour
{
    [SerializeField] private Ball _player;
    [SerializeField] private CoinsManager _coinsManager;

    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _reviveButton;
    [SerializeField] private Button _addMoneyButton;

    private bool _needUnmute;

    private int _moneyReward = 300;

    private void Start()
    {
        //_reviveButton.onClick.AddListener(() => YandexGame.vid .ShowRewarded(KEY_REVIVE));
        //_addMoneyButton.onClick.AddListener(() => _sdk.ShowRewarded(KeyMoney));
    }

    private void OnEnable()
    {
        YandexGame.CloseVideoEvent += VideoReward;
    }
    
    private void OnDisable()
    {
        YandexGame.CloseVideoEvent -= VideoReward;
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

    private void VideoReward(int id)
    {
        switch (id)
        {
            case 1:
                _player.Revive();
                break;
            case 2:
                _coinsManager.AddCoins(_moneyReward);
                break;
        }
    }
}
