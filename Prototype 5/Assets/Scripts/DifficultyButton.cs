using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); // Getting button componenet for our button
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Finding the Game Manager object and gettting the GameManager script component.

        button.onClick.AddListener(SetDifficulty); // Waiting for user mouse click on a difficulty button
    }

    private void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " Was clicked"); // Tells the console that the button we clicked EX: "Easy Button was clicked."
        gameManager.StartGame(difficulty); // Sending the "difficulty" variable to the GameManager script.
    }
}
