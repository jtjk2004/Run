using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundvol : MonoBehaviour
{
    public AudioSource weeeeee;
    // Start is called before the first frame update
    void Start()
    {
        weeeeee = GetComponent<AudioSource>();
        weeeeee.time = PlayerPrefs.GetFloat("audiotime");
        weeeeee.volume = (float)((float)PlayerPrefs.GetInt("volume")/100f);
    }
}
