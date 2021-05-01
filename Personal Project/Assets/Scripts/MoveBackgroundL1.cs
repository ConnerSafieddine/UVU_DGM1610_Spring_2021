using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundL1 : MonoBehaviour
{
    private float zBound = -40.3f;
    private float speed = 2.0f;
    private float worldOrigin = 0.0f;

    void Update() // Move the Layer 2 background down 2 meters per second. If the position is less than -40.3 then reset it's position.
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < zBound)
        {
            transform.position = Vector3.back * worldOrigin;
        }
    }
}
