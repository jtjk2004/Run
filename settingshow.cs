using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingshow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settings, back,audios, recruits, back0;
    // Update is called once per frame
    public void showlah()
    {
        audios.GetComponent<AudioSource>().time = 0.1f;
        audios.SetActive(false);
        audios.SetActive(true);
        settings.SetActive(true);
        back.SetActive(true);
    }

    public void recruit()
    {
        audios.GetComponent<AudioSource>().time = 0.1f;
        audios.SetActive(false);
        audios.SetActive(true);
        recruits.SetActive(true);
        back0.SetActive(true);
    }
}
