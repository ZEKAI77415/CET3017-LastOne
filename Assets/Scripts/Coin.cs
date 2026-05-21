using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCurrency currency = collision.GetComponent<PlayerCurrency>();

        if (currency != null)
        {
            currency.AddGold(value);
            Destroy(gameObject);
        }
    }
}