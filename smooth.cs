using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smooth : MonoBehaviour
{
    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.1f);
        ui.SetActive(false);
    }
}
