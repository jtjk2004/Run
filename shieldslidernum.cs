using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldslidernum : MonoBehaviour
{
    public Slider healthBarSlider;
    public GameObject shield,realshield,player;
    public bool gate = true;
    // Start is called before the first frame update
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
            shield.SetActive(false);
            realshield.SetActive(false);
            player.GetComponent<Player>().shield = false;
        }
    }
    IEnumerator decrease()
    {
        yield return new WaitForSeconds(0.055f);
        healthBarSlider.value --;
        gate = true;
    }
}
