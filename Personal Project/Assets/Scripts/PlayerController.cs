using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 16.0f;
    private float xBound = 9.0f;
    private float rotationSpeed = 50.0f;
    private float rotationLock;

    private AudioSource playerAudio;
    public AudioClip zap;
    public AudioClip boom;
    public AudioClip music;

    private SpawnManager spawnManager;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    private Rigidbody playerRb;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshCollider = GetComponent<MeshCollider>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.isGameActive)
        {
            MovePlayer();
            ConstrainPlayerPosition();
            IsShooting();
        }
    }

    // Moves the player horizontally
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

    private void IsShooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);
            playerAudio.PlayOneShot(zap, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
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
