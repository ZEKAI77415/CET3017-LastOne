using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject coinPrefab;

    private WaveManager waveManager;

    private void Start()
    {
        waveManager = FindFirstObjectByType<WaveManager>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (coinPrefab != null)
            {
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
            }

            if (waveManager != null)
            {
                waveManager.EnemyDied();
            }

            Destroy(gameObject);
        }
    }
}