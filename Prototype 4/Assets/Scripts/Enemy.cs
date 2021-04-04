using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 300.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // Getting Rigidbody Component
        enemyRb = GetComponent<Rigidbody>();
        // Finding Player Game Object
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // getting enemy position and player position difference
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
       // adding a force to enemy 
        enemyRb.AddForce(lookDirection * Time.deltaTime * speed);
        // If the enemy is out of bounds destroy the enemy
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
