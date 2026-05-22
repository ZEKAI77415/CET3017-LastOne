using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int baseHealth = 3;
    public GameObject coinPrefab;

    private TextMeshPro healthText;

    private int currentHealth;
    private int maxHealth;
    private WaveManager waveManager;
    private bool isDead = false;

    private void Awake()
    {
        healthText = GetComponentInChildren<TextMeshPro>();
    }

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
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth + "/" + maxHealth;
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