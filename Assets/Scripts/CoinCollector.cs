using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CoinCollector : MonoBehaviour
{
    public int CollectedCoinsCount { get; private set; }
    public int CollectedCoinsValue {  get; private set; }

    public void AddCoin(int amount)
    {
        CollectedCoinsCount++;
        CollectedCoinsValue += amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            AddCoin(coin.CoinValue);
            gameObject.SetActive(false);
        }
    }
}
