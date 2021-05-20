using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos= new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float startRate = 2;
    private PlayerController playerControllerScript;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public Button exitGame;
    public TextMeshProUGUI scoreText;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, startRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
        UpdateScore(0);
    }
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitGame.gameObject.SetActive(true);
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
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "SCORE: " + score;
    }
}
