using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyslider : MonoBehaviour
{
    public GameObject Player;
    public float healthh;
    void Start()
    {
        transform.localScale = new Vector3(0.08f,0.04f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3((float)(0.08*((float)Player.GetComponent<enemy>().health/healthh)),0.04f,1f);
        if(Player.GetComponent<enemy>().health < 1)
        {
            Destroy(gameObject);
        }
    }
}
