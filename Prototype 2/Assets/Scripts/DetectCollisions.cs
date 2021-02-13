using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Destroy this object (script applied)
        Destroy(gameObject);
        // Destroy other object (has trigger)
        Destroy(other.gameObject);
    }
}
