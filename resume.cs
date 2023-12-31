using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class resume : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject quit;
    public AudioSource backm;
    // Start is called before the first frame update
    // Update is called once per frame
    public void activeclick()
    {
        Time.timeScale = 1f;
        backm.Play();
        quit.SetActive(false);
    }
}
