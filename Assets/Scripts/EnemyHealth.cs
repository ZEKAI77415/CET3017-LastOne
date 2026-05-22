using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int baseHealth = 3;
    public GameObject coinPrefab;

    private int currentHealth;
    private WaveManager waveManager;
    private bool isDead = false;

    private void Start()
    {
        waveManager = FindFirstObjectByType<WaveManager>();

        if (waveManager != null)
        {
            currentHealth = baseHealth + waveManager.currentWave;
        }
        else
        {
            currentHealth = baseHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

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