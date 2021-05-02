using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 15;
    private float zDestroy = -10;

    private SpawnManager spawnManager;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    private AudioSource enemyBulletAudio;
    
    public AudioClip boom;
    public AudioClip bulletBoom;

    void Start() /* Find SpawnManager component for spawnManager, find the MeshRenderer componenet for meshRenderer, 
        find the BoxCollider component for boxCollider, and find the AudioSource componenet for enemyBulletAudio. */
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        enemyBulletAudio = GetComponent<AudioSource>();
    }
    
    void FixedUpdate() // Move the Enemy bullet down the screen 15 meters per second. If the bullet reaches -4 or less it will destroy the game object.
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);  

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player")) /* If the EnemyBullet touches the Collider for tagged "Player" then destroy the game object,
        disable the meshRenderer, disable the boxCollider, and play the enemyBulletAudio "boom". Make the game inactive, show the "Game Over" text and show the "Restart" button text. */
        {
            Destroy(other.gameObject); 
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            enemyBulletAudio.PlayOneShot(boom, 0.5f);

            spawnManager.isGameActive = false;
            spawnManager.gameOverText.SetActive(true);
            spawnManager.restartButton.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("Bullet")) /* If the EnemyBullet touches the Bullet collider then play the enemyBulletAudio "bulletBoom", 
            Destroy the Bullet object, disable the meshRenderer, disable the boxCollider and make the game active. */
        {
            enemyBulletAudio.PlayOneShot(bulletBoom, 0.2f);
            Destroy(other.gameObject);
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            spawnManager.isGameActive = true;
        }
    }
}
