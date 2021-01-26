﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//these are libraries full of commands used to talk to Unity
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float hInput;
    public float vInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * hInput);
    }
}
