using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float baseMoveSpeed = 2f;

    private float moveSpeed;
    private Transform player;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        WaveManager waveManager = FindFirstObjectByType<WaveManager>();

        if (waveManager != null)
        {
            moveSpeed = baseMoveSpeed + (waveManager.currentWave * 0.1f);
        }
        else
        {
            moveSpeed = baseMoveSpeed;
        }
    }

    private void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}