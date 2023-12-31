using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stagess, backs, sett,audios,recruits;
    // Update is called once per frame
    public void clicked()
    {
        audios.GetComponent<AudioSource>().time = 0.1f;
        audios.SetActive(false);
        audios.SetActive(true);
        stagess.SetActive(false);
        sett.SetActive(false);
        recruits.SetActive(false);
        backs.SetActive(false);
    }
}
