using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundL2 : MonoBehaviour
{
    private float zBound = -37.49f;
    private float speed = 1.0f;
    private float worldOrigin = 0.0f;

    void FixedUpdate() // Move the Layer 2 background down 1 meter per second. If the position is less than -37.49 then reset it's position.
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < zBound)
        {
            transform.position = Vector3.back * worldOrigin;
        }
    }
}