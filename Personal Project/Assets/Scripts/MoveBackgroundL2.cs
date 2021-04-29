using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundL2 : MonoBehaviour
{
    private float zBound = -37.49f;
    private float speed = 1.0f;
    private float worldOrigin = 0.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < zBound)
        {
            transform.position = Vector3.back * worldOrigin;
        }
    }
}