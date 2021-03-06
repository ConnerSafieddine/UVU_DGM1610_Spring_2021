﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20.0f;
    private float xRange = 24.0f;
    private float projectileOffset = 1.0f;

    public GameObject projectilePrefab;
    public float fireInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player moves left 10 it will prevent the player to move left more
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // If the player moves right 10 it will prevent the player to move right more
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // Getting player input A & D
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        
        // Getting input "space bar" shooting pizza as projectile from player position and offset the height by 1 meter
        if (Input.GetKeyDown(KeyCode.Space))   
        {
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + projectileOffset, transform.position.z), projectilePrefab.transform.rotation);
        }

    }
}
