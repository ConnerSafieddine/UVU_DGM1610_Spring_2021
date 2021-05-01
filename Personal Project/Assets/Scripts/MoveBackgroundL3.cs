using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundL3 : MonoBehaviour
{
    private float zBound = -40.94f;
    private float speed = 0.5f;
    private float worldOrigin = 0.0f;

    void Update() // Move the Layer 3 background down 0.5 meters per second. If the position is less than -40.94 then reset it's position.
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < zBound)
        {
            transform.position = Vector3.back * worldOrigin;
        }
    }
}