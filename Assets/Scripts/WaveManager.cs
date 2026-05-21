using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public int currentWave = 1;
    public int baseEnemyCount = 3;
    public float timeBetweenSpawns = 0.5f;

    private bool isSpawning;
    private bool shopOpened;
    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindFirstObjectByType<ShopManager>();
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning && !shopOpened)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
            {
                OpenShopAfterWave();
            }
        }
    }

    private IEnumerator StartWave()
    {
        isSpawning = true;
        shopOpened = false;

        int enemyCount = baseEnemyCount + currentWave;

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }

        isSpawning = false;
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("Enemy Prefab or Spawn Points not assigned.");
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    public void EnemyDied()
    {
    }

    private void OpenShopAfterWave()
    {
        shopOpened = true;

        if (shopManager != null)
        {
            shopManager.OpenShop();
        }
    }

    public void StartNextWaveFromShop()
    {
        currentWave++;
        StartCoroutine(StartWave());
    }
}