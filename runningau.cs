using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningau : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource uhm;
    void Start()
    {
        uhm.volume = (float)(((float)PlayerPrefs.GetInt("uivolume")/100f)*0.8f);
    }
    void Update()
    {
        if(uhm.time>1.75f)
        {
            uhm.time = 0f;
        }
    }
}
