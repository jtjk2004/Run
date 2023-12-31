using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button, audios;
    // Update is called once per frame
    public int x;
    public void stage1()
    {
        PlayerPrefs.SetFloat("audiotime",audios.GetComponent<AudioSource>().time);
        PlayerPrefs.SetInt("playerdamage",PlayerPrefs.GetInt("pplayerdamage"));
        PlayerPrefs.SetInt("ultidamage",PlayerPrefs.GetInt("pultidamage"));
        SceneManager.LoadScene("stage1");
    }

    public void S1()
    {
        PlayerPrefs.SetInt("stagesss",1);
    }
    public void S2()
    {
        PlayerPrefs.SetInt("stagesss",2);
    }
}
