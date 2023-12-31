using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barcont : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3((float)(PlayerPrefs.GetInt("volume"))/100,1,1);
    }
}
