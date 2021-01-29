using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset = new Vector3(18f, 2.97f, 9f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Camera follows player
        transform.position = Player.transform.position + offset;
    }
}
