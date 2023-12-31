using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class doubledamage : MonoBehaviour
{
    public Slider healthBarSlider;
    public GameObject coinn, player, colour;
    public bool gate = true;
    // Start is called before the first frame update
    void Start()
    {
        coinn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBarSlider.value>0)
        {
            if(gate)
            {
                gate = false;
                StartCoroutine(decrease());
            }
        }
        else
        {
            PlayerPrefs.SetInt("playerdamage",PlayerPrefs.GetInt("pplayerdamage"));
            PlayerPrefs.SetInt("ultidamage",PlayerPrefs.GetInt("pultidamage"));
            colour.SetActive(false);
            coinn.SetActive(false);
        }
    }
    IEnumerator decrease()
    {
        yield return new WaitForSeconds(0.04f);
        healthBarSlider.value --;
        gate = true;
    }
    
}
