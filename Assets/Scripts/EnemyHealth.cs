using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int baseHealth = 3;
    public GameObject coinPrefab;

    private int currentHealth;
    private int maxHealth;
    private WaveManager waveManager;
    private bool isDead = false;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    private void Start()
    {
        waveManager = FindFirstObjectByType<WaveManager>();

        if (waveManager != null)
        {
            maxHealth = baseHealth + waveManager.currentWave;
        }
        else
        {
            maxHealth = baseHealth;
        }

        currentHealth = maxHealth;
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