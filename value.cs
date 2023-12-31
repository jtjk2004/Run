using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class value : MonoBehaviour
{
    public GameObject Player;
    public Slider healthBarSlider;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        healthBarSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBarSlider.value = Player.GetComponent<Player>().health;
    }
}

