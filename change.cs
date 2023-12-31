using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class change : MonoBehaviour
{
    public GameObject attackup,shield;
    private bool check = true;
    void Start()
    {
        attackup.SetActive(false);
        shield.SetActive(false);
    }
    // Start is called before the first frame update
    // Update is called once per frame
    public void clicky()
    {
        if(check)
        {
            check = false;
            attackup.SetActive(true);
            shield.SetActive(true);
        }
        else
        {
            check = true;
            attackup.SetActive(false);
            shield.SetActive(false);
        }

    }
}
