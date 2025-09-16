using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRange = 9f;

    private void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        return new Vector3(
            Random.Range(-spawnRange, spawnRange),
            0,
            Random.Range(-spawnRange, spawnRange)
        );
    }
}
