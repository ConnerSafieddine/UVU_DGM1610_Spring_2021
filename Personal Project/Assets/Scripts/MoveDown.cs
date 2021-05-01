using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float zDestroy = -4.0f;
    private float speed = 300.0f;
    private float bulletSpawnDelay = 0.0f;
    private float bulletSpawnTime = 1.6f;

    private Rigidbody objectRb;
    private AudioSource enemyAudio;
    private SpawnManager spawnManager;

    public GameObject enemyBullet;
    public AudioClip enemyZap;
    public AudioClip boom;
    
    void Start() // When the starts spawn the EnemyBullet every 1.6 seconds. Find the SpawnManager componenet for the spawnManager variable and find the enemyAudio and get the AudioSource component.
    {
        objectRb = GetComponent<Rigidbody>();

        InvokeRepeating("SpawnEnemyBullet", bulletSpawnDelay, bulletSpawnTime);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        enemyAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        objectRb.AddForce(Vector3.back * speed * Time.deltaTime); /* Add a backward force to the rigidbody. If the object is -4 zposition then destroy the object. 
        Make the game over and show the Game Over text as well as the restart button. */

        if (transform.position.z < zDestroy) // If the Obstical gets to -4 on the z axis then destroy the object, make the game inactive, show the "Game Over" text, and show the "Restart" button text.
        {
            Destroy(gameObject);
            spawnManager.isGameActive = false;
            spawnManager.gameOverText.SetActive(true);
            spawnManager.restartButton.gameObject.SetActive(true);
        }
    }

    void SpawnEnemyBullet() // Spawn the bullet with current position and rotation. Add the enemy audio "enemyZap".
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
        enemyAudio.PlayOneShot(enemyZap, 0.1f);
    }
}
