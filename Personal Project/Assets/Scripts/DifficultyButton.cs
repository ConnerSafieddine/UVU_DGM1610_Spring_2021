using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private SpawnManager spawnManager;
    public Button button;
    public int difficulty;
    public bool levelStart = false;

    void Start() // Find SpawnManager component for spawnManager. Find the Button componenet for button. When the button is clicked play the SetDifficulty method. 
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    private void Update() // If the game is active show the "Title Text".
    {
        if (spawnManager.isGameActive == true)
        {
            GameObject.Find("Title Text").SetActive(false);
        }
    }

    public void SetDifficulty() // If the game is not active then ask the player for difficulty.
    {
        if (spawnManager.isGameActive == false)
        {
            Debug.Log(button.gameObject.name + " Was Clicked");
            spawnManager.StartGame(difficulty);
        }
    }
}
