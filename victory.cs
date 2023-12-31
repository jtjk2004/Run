using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
    public GameObject canvas, fluffy;
    public AudioSource backm;
    // Update is called once per frame
    void Start()
    {
        canvas.SetActive(false);
        fluffy.SetActive(false);
    }
    public void victoryy()
    {
        PlayerPrefs.SetFloat("audiotime",(float)backm.time);
        SceneManager.LoadScene("page");
        PlayerPrefs.SetInt("coin",PlayerPrefs.GetInt("coin")+5);
    }
    public void lose()
    {
        PlayerPrefs.SetFloat("audiotime",(float)backm.time);
        SceneManager.LoadScene("page");
    }
}
