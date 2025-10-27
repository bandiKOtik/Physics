using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CoinCollector : MonoBehaviour
{
    public int CollectedCoinsCount { get; private set; }
    public int CollectedCoinsValue {  get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            CollectedCoinsCount++;
            CollectedCoinsValue += coin.CoinValue;
            coin.gameObject.SetActive(false);
        }
    }
}
