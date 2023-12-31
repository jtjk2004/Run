using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Player;
    public BoxCollider2D collider1;
    void Start()
    {
        collider1 = GetComponent<BoxCollider2D>();
        collider1.enabled = !collider1.enabled;
    }
    void Update()
    {
        if(Player.GetComponent<Player>().checktack==true)
        {
            collider1.enabled = collider1.enabled;
        }
        else
        {
            collider1.enabled = !collider1.enabled;
        }
    }
}
