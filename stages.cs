using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stages : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stagess, back,audios;
    // Update is called once per frame
    public void onclicked()
    {
        audios.GetComponent<AudioSource>().time = 0.1f;
        audios.SetActive(false);
        audios.SetActive(true);
        stagess.SetActive(true);
        back.SetActive(true);
    }
}
