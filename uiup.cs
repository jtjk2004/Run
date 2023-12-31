using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiup : MonoBehaviour
{
    // Start is called before the first frame update
    public void therewego()
    {
        if(PlayerPrefs.GetInt("uivolume")<100)
        {
            PlayerPrefs.SetInt("uivolume",PlayerPrefs.GetInt("uivolume")+10);
        }
    }
}
