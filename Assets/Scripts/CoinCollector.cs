using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CoinCollector : MonoBehaviour
{
    public int CollectedCoins {  get; private set; }

    public void AddCoin(int amount)
    {
        CollectedCoins += amount;
    }
}
