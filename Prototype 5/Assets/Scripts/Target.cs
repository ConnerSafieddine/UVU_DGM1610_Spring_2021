using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = 3.5f;

    public ParticleSystem explosionParticle;
    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the rigidbody component 
        targetRb = GetComponent<Rigidbody>();
        // Finding the game manager script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Set "gameManager" variable to the "Game Manager" object. Find the GameManager component.

        
        targetRb.AddForce(RandomForce(), ForceMode.Impulse); // Add a random force up to the object that is immediate. 
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse); // Add a random Torque to the object that is immediate.

        transform.position = RandomSpawnPos(); // Spawn the object in a random position.
    }

    private void OnMouseDown() // When the user clicks their left mouse over the object destroy the game object, update the score value that is in the gameManager script, and spawn a explosion particle.
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other) // When our object touches our sensor destroy the game object and make the game stop. However, if the object is tagged "Bad" continue the game. 
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector2 RandomForce() // Add a random force up on the x and y axis. 
    {
        return Vector2.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque() // Add a random torque on the x and y axis. 
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector2 RandomSpawnPos() // Spawn the object randomly on the x axis and -3.5 on the y axis. 
    {
        return new Vector2(Random.Range(-xRange, xRange), -ySpawnPos);
    }

    private float DoubleNumber(float number) // "Double number" is a return value of "number" * "number" * 2 in float form.
    {
        return number *= 2;
    }
}
