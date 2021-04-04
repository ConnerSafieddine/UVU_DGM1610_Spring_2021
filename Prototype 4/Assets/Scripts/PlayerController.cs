using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject powerupIndicator;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private float powerupStrength = 15.0f;
    private float speed = 200.0f;
    public bool hasPowerUp = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Getting the players Rigidbody
        playerRb = GetComponent<Rigidbody>();
        // Finding the focal point
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        // Putting powerupIndicator at player position and offsetting that position
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        // Getting vertical input for player
        float forwardInput = Input.GetAxis("Vertical");
        // Adding a forward force to player Rigidbody
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed * Time.deltaTime);
    }

    // OnTriggerEnter is called when the player collides with the powerup
    private void OnTriggerEnter(Collider other)
    {
        // If the player grabs the Powerup then set the powerup as active and destroy the gameobject
        if(other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);

            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        // Adding a timer for powerup. 7 seconds until the powerupIndicator is inactive
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            // Gets the enemy's rigidbody component 
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            // Gets the position of the enemy in relation to the player
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            // OnCollision kicks enemy back with a force
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
            // Report player collision with pick up
            Debug.Log("Collided with: " + collision.gameObject.name + " With powerup set to " + hasPowerUp);
        }
    }
}
