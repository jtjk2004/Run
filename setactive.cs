using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setactive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject coinns, player, colour;

    // Update is called once per frame
    void Start()
    {
        colour.SetActive(false);
    }
    void Update()
    {
        if(coinns.GetComponent<Slider>().value == 0 && player.GetComponent<Player>().powerup == true)
        {
            player.GetComponent<Player>().powerup = false;
            coinns.GetComponent<Slider>().value = 100;
            coinns.SetActive(true);
            colour.SetActive(true);
        }
    }
}
