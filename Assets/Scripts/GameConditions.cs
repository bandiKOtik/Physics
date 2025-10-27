using UnityEngine;

public class GameConditions : MonoBehaviour
{
    private bool _isGameActive;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private float _timer = 60f;
    [SerializeField] private Coin[] _coins;
    private CoinCollector _playerCollector;

    public float Timer => _timer;
    public int RemainCoins { get; private set; }

    private void Awake()
    {
        _playerCollector = _playerObject.GetComponent<CoinCollector>();
        _isGameActive = true;
    }

    private void Update()
    {
        RemainCoins = _coins.Length - _playerCollector.CollectedCoinsCount;

        UpdateGameRestrictions();
    }

    private bool IsAllCoinsCollected()
    {
        if (_coins.Length - _playerCollector.CollectedCoinsCount == 0)
            return true;
        else
            return false;
    }

    private void UpdateGameRestrictions()
    {
        if (_timer > 0 && _isGameActive)
        {
            _timer -= Time.deltaTime;
        }
        else if (_timer <= 0)
        {
            EndGameWithLog("You loose!");
            return;
        }

        if (IsAllCoinsCollected())
        {
            EndGameWithLog("You win!");
        }
    }

    private void EndGameWithLog(string message)
    {
        _playerObject.SetActive(false);
        _isGameActive = false;
        Debug.Log(message);
    }
}
