using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerUpPrefab;
    [SerializeField] private float spawnRange = 9f;    
    [SerializeField] private int waveCount = 1;
    private GameObject currentPowerUp;

    private void Update()
    {
        if (Enemy.ActiveCount == 0)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
            if (currentPowerUp == null)
            {
                currentPowerUp = Instantiate(powerUpPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        return new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0,
            Random.Range(-spawnRange, spawnRange)
        );
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

}
