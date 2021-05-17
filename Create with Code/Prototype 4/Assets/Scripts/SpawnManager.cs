using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    private int enemyCount;
    private int waveNumber = 1;
    public GameObject powerupPrefab;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    public Button exitButton;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        if(isGameActive)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }
        
    }
    void Update()
    {
        if (isGameActive)
        {
            enemyCount = FindObjectsOfType<Enemy>().Length;
            if (enemyCount == 0)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);

                Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            }
        }
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting!");
    }
}
