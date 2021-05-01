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
    

    public void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        bulletAudio = GetComponent<AudioSource>();
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z > zDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            bulletAudio.PlayOneShot(boom, 0.5f);
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            Destroy(other.gameObject);
            spawnManager.UpdateScore(pointValue);
        }
    }
}
