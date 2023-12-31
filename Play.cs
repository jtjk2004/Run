using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        PlayerPrefs.SetFloat("audiotime",0f);
        PlayerPrefs.SetInt("ulticount",3);
        PlayerPrefs.SetInt("ultidamage",3);
        PlayerPrefs.SetInt("playerdamage",1);
        PlayerPrefs.SetInt("pultidamage",3);
        PlayerPrefs.SetInt("pplayerdamage",1);
        PlayerPrefs.SetInt("playerdamage",PlayerPrefs.GetInt("pplayerdamage"));
        PlayerPrefs.SetInt("ultidamage",PlayerPrefs.GetInt("pultidamage"));
        SceneManager.LoadScene("page");
    } 
}