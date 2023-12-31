using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float dieTime;
    public GameObject die;
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
       if(!collision.gameObject.CompareTag("bullet"))
       {
            StartCoroutine(Die()); 
       }
    }
    void OnTriggerEnter2D(Collider2D collid)
    {
        if(collid.tag == "shield")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);
       StartCoroutine(Die());
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
