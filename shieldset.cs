using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shieldset : MonoBehaviour
{
    public GameObject shield,player,shieldslide;
    public Slider healthBarSlider;
    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
        shieldslide.SetActive(false);
        healthBarSlider.value = 0;
        player.GetComponent<Player>().shield = false;
    }

    // Update is called once per frame
    public void shieldon()
    {
        if(player.GetComponent<Player>().coins>=15 && healthBarSlider.value==0)
        {
            player.GetComponent<Player>().coins-=15;
            shield.SetActive(true);
            player.GetComponent<Player>().shield = true;
            shieldslide.SetActive(true);
            healthBarSlider.value = 100;
        }
    }
}
