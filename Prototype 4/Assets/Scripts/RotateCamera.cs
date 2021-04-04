﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float rotationSpeed = 50.0f;
    // Update is called once per frame
    void Update()
    {
        // Getting horizontal input to rotate the camera
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.down, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
