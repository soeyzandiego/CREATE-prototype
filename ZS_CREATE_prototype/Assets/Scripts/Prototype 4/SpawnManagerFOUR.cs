using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerFOUR : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerupPrefab;
    [SerializeField] float spawnRange = 9f;

    int enemyCount;
    int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(waveNumber);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0) 
        { 
            waveNumber++;
            SpawnWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPos(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void SpawnWave(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPos(), enemyPrefab.transform.rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Vector3.zero, spawnRange);
    }
}
