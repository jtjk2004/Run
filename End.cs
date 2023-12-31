using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public GameObject ender;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(ender.GetComponent<Player>().health==0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
