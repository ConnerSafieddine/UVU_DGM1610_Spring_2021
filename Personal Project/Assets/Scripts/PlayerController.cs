using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const float speed = 16.0f;
    private float xBound = 9.0f;
    private float rotationSpeed = 50.0f;
    private float rotationLock;

    private AudioSource playerAudio;
    public AudioClip zap;
    public AudioClip boom;

    private SpawnManager spawnManager;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    private Rigidbody playerRb;
    public GameObject bullet;

    void Start() /* Get the Rigidbody component for playerRb, get the SpawnManager component for spawnManager, get the MeshRenderer component for meshRender, 
        get the MeshCollider component for meshCollider, get the AudioSource component for playerAudio. */
    {
        playerRb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        playerAudio = GetComponent<AudioSource>();
    }

    void Update() // If the game is active allow the MovePlayer, ConstrainPlayerPosition, and IsShooting methods to run.
    {
        if (spawnManager.isGameActive)
        {
            MovePlayer();
            ConstrainPlayerPosition();
            IsShooting();
        }
    }

    // Moves the player horizontally using global coordinates.
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime, Space.World);
    }

    // Prevent the player from leaving left or right of screen
    void ConstrainPlayerPosition()
    {
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }

    private void IsShooting() // If the player presses the space bar spawn a bullet and play the playerAudio zap sound.
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            playerAudio.PlayOneShot(zap, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other) /* If the player touches object tagged "Enemy" collider then play boom audio, disable the meshRender, disable the meshCollider. 
        Make the game inactive, show the "Game Over" text, show the "Restart" button text. */
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            playerAudio.PlayOneShot(boom, 0.5f);
            meshRenderer.enabled = false;
            meshCollider.enabled = false;

            spawnManager.isGameActive = false;
            spawnManager.gameOverText.gameObject.SetActive(true);
            spawnManager.restartButton.gameObject.SetActive(true);
        }
    }
}
