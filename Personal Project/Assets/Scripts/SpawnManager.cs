using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    public Button startButton;

    public bool isGameActive;
    
    private float zEnemySpawn = 12.0f;
    private float xSpawnRange = 9.0f;
    private float ySpawn = 0.75f;
    private float enemySpawnTime = 2.3f;
    private float startDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
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

    public void StartGame()
    {
        if (startButton.IsPointerOverEventSystemObject())
        {

        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
