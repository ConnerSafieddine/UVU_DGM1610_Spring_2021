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
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    private void Update()
    {
        if (spawnManager.isGameActive == true)
        {
            GameObject.Find("Title Text").SetActive(false);
        }
    }

    // Update is called once per frame
    public void SetDifficulty()
    {
        if (spawnManager.isGameActive == false)
        {
            Debug.Log(button.gameObject.name + " Was Clicked");
            spawnManager.StartGame(difficulty);
        }
    }
}
