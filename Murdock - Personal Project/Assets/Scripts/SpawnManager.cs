using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    private float zEnemySpawn = 12f;
    private float xSpawnRange = 16f;
    private float zPowerupRange = 5f;
    private float ySpawn = 0.75f;
    private float powerupSpawnTime = 5f;
    private float enemySpawnTime = 1f;
    private float startDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }
    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerupRange, zPowerupRange);
        Vector3 spawnPos = new Vector3(randomZ, ySpawn, randomZ);
        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
}
