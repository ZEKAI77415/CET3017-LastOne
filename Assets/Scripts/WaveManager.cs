using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public int currentWave = 1;
    public int baseEnemyCount = 3;
    public float timeBetweenSpawns = 0.5f;

    private int enemiesAlive;
    private bool isSpawning;
    private ShopManager shopManager;

    private void Start()
    {
        shopManager = FindFirstObjectByType<ShopManager>();
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        isSpawning = true;

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
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        enemiesAlive++;
    }

    public void EnemyDied()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0 && !isSpawning)
        {
            OpenShopAfterWave();
        }
    }

    private void OpenShopAfterWave()
    {
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