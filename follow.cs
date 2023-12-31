using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(enemy.GetComponent<enemy>().health>0)
        {
            transform.position = enemy.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
