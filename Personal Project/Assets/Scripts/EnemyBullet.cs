using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 10;
    private float zDestroy = -4;

    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>(); // Finding the SpawnManager game object and getting the script component.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Enemy bullet will move down the screen. 

        if (transform.position.z < zDestroy) // If the bullet reaches -4 or less it will destroy the game object.
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) // If the game object is not the Enemy than destroy the game object and the other object. Also make the game over and activate "Game Over" text along with the restart button.
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            spawnManager.isGameActive = false;
            spawnManager.gameOverText.SetActive(true);
            spawnManager.restartButton.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            spawnManager.isGameActive = true;
        }
    }
}
