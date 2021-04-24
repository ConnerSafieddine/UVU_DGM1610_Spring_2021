using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;

    private int score;
    private float spawnRate = 1; 

    IEnumerator SpawnTarget()
    {
        while(isGameActive) // While the game is active spawn random targets every 1 second.
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd) // Update score and show the score in the UI.
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() // When the game is over show the "Game Over" text UI, show the "Restart" button UI and make the game NOT active.
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame() // When we restart the game reload the current scene.
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true; // "isGameActive" is now true.
        score = 0; // "score" is set to 0.
        spawnRate /= difficulty; // The Spawnrate for the objects is divided by the difficulty.

        StartCoroutine(SpawnTarget()); // Continues to spawn objects after the next frame.
        UpdateScore(0); // When the game starts make the "UpdateScore" value back to zero.

        titleScreen.gameObject.SetActive(false); // When the game starts make the "Title Screen" not active because we already have it active in the inspector.
    }

     public void StartGame()
    {
        isGameActive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
}
