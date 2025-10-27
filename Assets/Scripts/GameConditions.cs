using UnityEngine;

public class GameConditions : MonoBehaviour
{
    private bool _isGameActive;
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private float _timer = 60f;
    [SerializeField] private Coin[] _coins;
    private bool _notAttachedCoinsExeption = false;

    public float Timer => _timer;
    public int RemainCoins { get; private set; }

    private void Awake()
    {
        CheckOnErrors();

        _isGameActive = true;
    }

    private void FixedUpdate()
    {
        UpdateGameRestrictions();
    }

    private bool IsAllCoinsCollected()
    {
        if (_notAttachedCoinsExeption == false)
        {
            bool allCoinsCollected = true;
            int remainCoinsTemp = 0;

            for (int i = 0; i < _coins.Length; i++)
            {
                if (_coins[i].gameObject.activeSelf)
                    remainCoinsTemp++;
            }

            if (remainCoinsTemp > 0)
                allCoinsCollected = false;

            RemainCoins = remainCoinsTemp;
            return allCoinsCollected;
        }
        else { return false; }
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

    private void CheckOnErrors()
    {
        if (_coins.Length == 0)
        {
            _notAttachedCoinsExeption = true;
            Debug.LogError($"Coins not attached to array in: {gameObject.name}!");
        }

        if (_timer == 0)
        {
            Debug.LogError($"Timer is set to 0 on Awake in: {gameObject.name}!");
        }

        if (_playerObject == null)
        {
            Debug.LogError($"Player object not attached to: {gameObject.name}!");
        }
    }
}
