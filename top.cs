using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
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
            player.GetComponent<Player>().top = true;
        }
    }
    void OnTriggerExit2D(Collider2D ground)
    {
        if(ground.tag == "ground")
        {
            player.GetComponent<Player>().top = false;
        }
    }
}
