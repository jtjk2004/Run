using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
    void OnTriggerEnter2D(Collider2D ground)
    {
        if(ground.tag == "ground")
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.GetComponent<Player>().isGrounded = true;
        }
    }
}
