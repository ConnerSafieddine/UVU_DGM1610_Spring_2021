using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundL1 : MonoBehaviour
{
    private float zBound = -40.3f;
    private float speed = 2.0f;
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
