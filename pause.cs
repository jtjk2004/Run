using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pause : MonoBehaviour
{
    public AudioSource click, backmusic;
    public GameObject system;
    // Start is called before the first frame update
    // Update is called once per frame
    public void systemclick()
    {
        click.enabled = false;
        click.enabled = true;
        click.time =0.1f;
        backmusic.Pause();
        system.SetActive(true);
        Time.timeScale = 0f;
    }
}
