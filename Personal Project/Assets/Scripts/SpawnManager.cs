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

    public void Start() // Find the DifficultyButton component for difficultyButton.
    {
        difficultyButton = GameObject.Find("Title Text").GetComponent<DifficultyButton>();
    }

    public void StartGame(int difficulty) // Spawn the enemy depending on the difficulty chosen by the player, make the game active, set the score to 0, and spawn a random enemy.
    {
        enemySpawnTime /= difficulty;
        isGameActive = true;
        score = 0;
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime); // Enemy spawns in seconds. Seconds depend on players chosen difficulty.
    }

    void SpawnRandomEnemy()
    {
        if(isGameActive == true) // If the game is active spawn a random enemy between -9x to 9x. Spawn 1 of the 3 enemys from the array.
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length); 

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    public void RestartGame() // Reload the scene when this method is called.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int scoreToAdd) // Update the score and change the "Score" hud to the players score.
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
}
