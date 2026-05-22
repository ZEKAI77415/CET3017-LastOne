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

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayCoinPickup();
            }

            Destroy(gameObject);
        }
    }
}