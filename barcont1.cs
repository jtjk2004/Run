using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barcont1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        transform.localScale = new Vector3((float)(PlayerPrefs.GetInt("uivolume"))/100,1,1);
    }
}
