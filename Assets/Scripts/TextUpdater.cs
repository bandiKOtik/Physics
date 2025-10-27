using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    [SerializeField] private Text _timerText, _coinsText, _collectedCoinsText;
    [SerializeField] private GameConditions _gameConditions;
    [SerializeField] private CoinCollector _coinCollector;

    void Update()
    {
        if (_timerText != null && _gameConditions != null)
        {
            _timerText.text = $"Time left: {_gameConditions.Timer.ToString("0.00")}";
        }

        if (_coinsText != null && _gameConditions != null)
        {
            _coinsText.text = $"Remain coins: {_gameConditions.RemainCoins}";
        }

        if (_collectedCoinsText != null && _coinCollector != null)
        {
            _collectedCoinsText.text = $"Collected Coins: {_coinCollector.CollectedCoinsValue}";
        }
    }
}
