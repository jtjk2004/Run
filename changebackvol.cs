using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changebackvol : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource mama;
    // Update is called once per frame
    public void herewego()
    {
        if(PlayerPrefs.GetInt("volume")<100)
        {
            PlayerPrefs.SetInt("volume",PlayerPrefs.GetInt("volume")+10);
            mama.volume = (float)((float)PlayerPrefs.GetInt("volume")/100f);
        }
    }
}
