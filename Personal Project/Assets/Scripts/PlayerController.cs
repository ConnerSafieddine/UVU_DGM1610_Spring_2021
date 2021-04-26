using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 12.0f;
    private float xBound = 9.0f;
    private Rigidbody playerRb;
    public GameObject bullet;
    public SpawnManager spawnManager;
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        spawnManager.isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.isGameActive == true && 
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
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has hit the enemy");
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
}
