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
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>(); // Finding the SpawnManager game object and getting the script component.
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        enemyBulletAudio = GetComponent<AudioSource>();
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
            Destroy(other.gameObject);
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            enemyBulletAudio.PlayOneShot(boom, 0.5f);

            spawnManager.isGameActive = false;
            spawnManager.gameOverText.SetActive(true);
            spawnManager.restartButton.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyBulletAudio.PlayOneShot(bulletBoom, 0.2f);
            Destroy(other.gameObject);
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            spawnManager.isGameActive = true;
        }
    }
}
