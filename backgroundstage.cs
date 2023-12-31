using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundstage : MonoBehaviour
{
    public GameObject stage1,stage2;
    private int x;
    // Start is called before the first frame update
    void Start()
    {
        x = PlayerPrefs.GetInt("stagesss");
        if(x==1)
        {
            stage1.SetActive(true);
        }
        if(x==2)
        {
            stage2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
