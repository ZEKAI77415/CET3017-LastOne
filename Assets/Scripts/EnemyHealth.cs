using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;
    public GameObject coinPrefab;

    private WaveManager waveManager;
    private bool isDead = false;

    private void Start()
    {
        waveManager = FindFirstObjectByType<WaveManager>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        if (health <= 0)
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