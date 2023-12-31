using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yes : MonoBehaviour
{
    public AudioSource backm;    
    // Start is called before the first frame update
    // Update is called once per frame
    public void goback()
    {
        PlayerPrefs.SetFloat("audiotime",(float)backm.time);
        Time.timeScale = 1f;
        SceneManager.LoadScene("page");
    }
}
