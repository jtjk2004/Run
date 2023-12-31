using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ulti : MonoBehaviour
{
    public int ulticount, curcount;
    // Start is called before the first frame update
    void Start()
    {
        curcount = 0;
        ulticount = PlayerPrefs.GetInt("ulticount");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1f,(float)((float)curcount/(float)ulticount),1f);
    }
}
