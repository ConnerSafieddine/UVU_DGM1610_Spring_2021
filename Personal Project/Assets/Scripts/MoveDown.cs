using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float zDestroy = -4.0f;
    private float speed = 5.0f;
    private float bulletSpawnDelay = 0.0f;
    private float bulletSpawnTime;
    private Rigidbody objectRb;
    public GameObject enemyBullet;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();

        InvokeRepeating("SpawnEnemyBullet", bulletSpawnDelay, bulletSpawnTime);
        bulletSpawnTime = Random.Range(1, 3);

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRb.AddForce(Vector3.forward * -speed);
        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
            spawnManager.isGameActive = false;
            spawnManager.gameOverText.SetActive(true);
            spawnManager.restartButton.gameObject.SetActive(true);
            Debug.Log("Game Over");
        }
    }

    void SpawnEnemyBullet()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
    }
}
