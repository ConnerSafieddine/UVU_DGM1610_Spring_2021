using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject gameOverText;
    public Button restartButton;
    public Button startButton;

    public TextMeshProUGUI scoreText;

    private DifficultyButton difficultyButton;

    public bool isGameActive;
    
    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 9.0f;
    private float ySpawn = 0.75f;
    private float enemySpawnTime = 3.5f;
    private float startDelay = 1.3f;

    public int score;

    public void Start()
    {
        difficultyButton = GameObject.Find("Title Text").GetComponent<DifficultyButton>();
    }

    public void StartGame(int difficulty)
    {
        enemySpawnTime /= difficulty;
        isGameActive = true;
        score = 0;
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
    }

    void SpawnRandomEnemy()
    {
        if(isGameActive == true)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
