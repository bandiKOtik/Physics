using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue = 1;
    public int CoinValue {  get; private set; }

    private void Awake()
    {
        CoinValue = _coinValue;
    }
}
