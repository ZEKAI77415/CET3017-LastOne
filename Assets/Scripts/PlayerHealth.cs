using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public float damageCooldown = 1f;

    private int currentHealth;
    private float lastDamageTime;

    public int CurrentHealth => currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (Time.time < lastDamageTime + damageCooldown)
        {
            return;
        }

        lastDamageTime = Time.time;
        currentHealth -= damage;

        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void IncreaseMaxHealth()
    {
        maxHealth += 2;
        currentHealth += 2;
    }
}

