using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 16.0f;
    private float xBound = 9.0f;
    private float rotationLimit = 20.0f;
    private float rotationSpeed = 50.0f;
    private Rigidbody playerRb;
    public GameObject bullet;
    public SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.isGameActive)
        {
            MovePlayer();
            ConstrainPlayerPosition();
            IsShooting();
            PivotInput();
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            spawnManager.isGameActive = false;
            spawnManager.gameOverText.gameObject.SetActive(true);
            spawnManager.restartButton.gameObject.SetActive(true);
        }
    }

    private void PivotInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        if (transform.rotation.z > 20)
        {
            transform.Rotate(0,0,20); // *We need to lock the z position somehow.*
        }
    }
}
