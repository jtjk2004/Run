using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerupdis : MonoBehaviour
{
    public GameObject weee, player;
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = !enabled;
        StartCoroutine(show());
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            weee.SetActive(false);
            PlayerPrefs.SetInt("playerdamage",PlayerPrefs.GetInt("pplayerdamage")*2);
            PlayerPrefs.SetInt("ultidamage",PlayerPrefs.GetInt("pultidamage")*2);
        }
    }
    IEnumerator show()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<BoxCollider2D>().enabled = enabled;
    }
}
