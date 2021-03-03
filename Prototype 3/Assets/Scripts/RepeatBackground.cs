using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    public float repeatWidth = 112.8f;
    // Start is called before the first frame update
    void Start()
    {
        // Set start position to current position
        startPos = transform.position;
        // Divided the width of the background on x axis by 2
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Repeating background on x axis
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }

    }
}