using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 20;
    private float zDestroy = 20;

    private int pointValue = 10;

    private SpawnManager spawnManager;
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;
    private AudioSource bulletAudio;
    public AudioClip boom;
    

    public void Start() // On Start find the SpawnManager, MeshRenderer, BoxCollider and bulletAudio and find their componenets respectively.
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        bulletAudio = GetComponent<AudioSource>();
        
    }

    void FixedUpdate() // On Update add a forward speed to the bullet in seconds.
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > zDestroy) // If the object gets to 20 on the z axis then destroy the game object.
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) /* If the bullet hits a trigger tagged "Enemy" then add bullet audio "boom", 
            disable the meshRenderer, disable the boxCollider, destroy the game object tagged "Enemy" and update the score by it's point value." */

        {
            bulletAudio.PlayOneShot(boom, 0.5f);
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            Destroy(other.gameObject);
            spawnManager.UpdateScore(pointValue);
        }
    }
}
