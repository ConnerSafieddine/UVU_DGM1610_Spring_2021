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
    
    // Start is called before the first frame update. Get objectRb rigidbody. Repeat spawning the enemy bullet with a random spawn time
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();

        InvokeRepeating("SpawnEnemyBullet", bulletSpawnDelay, bulletSpawnTime);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        enemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.back * speed * Time.deltaTime); /* Add a backward force to the rigidbody. If the object is -4 zposition then destroy the object. 
        Make the game over and show the Game Over text as well as the restart button. */

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
            spawnManager.isGameActive = false;
            spawnManager.gameOverText.SetActive(true);
            spawnManager.restartButton.gameObject.SetActive(true);
        }
    }

    void SpawnEnemyBullet() // Spawn the bullet with current position and rotation.
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
        enemyAudio.PlayOneShot(enemyZap, 0.1f);
    }
}
