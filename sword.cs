using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    // Update is called once per frame
    IEnumerator CountDownTimer()
    {
        
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
