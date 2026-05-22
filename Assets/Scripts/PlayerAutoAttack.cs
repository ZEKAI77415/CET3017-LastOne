using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float attackRange = 8f;
    public float attackCooldown = 0.5f;
    public int bulletDamage = 1;

    private float attackTimer;

    public int CurrentDamage => bulletDamage;
    public float CurrentAttackCooldown => attackCooldown;
    public float AttacksPerSecond => 1f / attackCooldown;

    private void Update()
    {
        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            Transform target = FindNearestEnemy();

            if (target != null)
            {
                Shoot(target);
                attackTimer = attackCooldown;
            }
        }
    }

    private Transform FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform nearestEnemy = null;
        float nearestDistance = attackRange;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        return nearestEnemy;
    }

    private void Shoot(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayShoot();
        }

        Vector2 direction = target.position - transform.position;

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if (bulletScript != null)
        {
            bulletScript.damage = bulletDamage;
            bulletScript.SetDirection(direction);
        }
    }

    public void IncreaseDamage()
    {
        bulletDamage += 1;
    }

    public void IncreaseAttackSpeed()
    {
        attackCooldown *= 0.9f;

        if (attackCooldown < 0.1f)
        {
            attackCooldown = 0.1f;
        }
    }
}