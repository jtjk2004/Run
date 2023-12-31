using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class summoncolor : MonoBehaviour
{
    public Image image;
    public Sprite darkk;
    public Sprite lightt;
    public GameObject canvas1, canvas2,click;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        image = GetComponent<Image>();
        image.sprite = darkk;
    }

    // Update is called once per frame
    public void activecolor()
    {
        if(image.sprite==darkk)
        {
            image.sprite = lightt;
        }
        else
        {
            image.sprite = darkk;
        }
    }

    public void pull1()
    {
        click.SetActive(false);
        click.SetActive(true);
        PlayerPrefs.SetInt("pull",1);
        PlayerPrefs.SetInt("material1",Random.Range(0,1000));
        PlayerPrefs.SetInt("i",0);
        canvas1.SetActive(true);
        StartCoroutine(dunnowhy());
    }

    public void pull10()
    {
        click.SetActive(false);
        click.SetActive(true);
        PlayerPrefs.SetInt("pull",10);
        for(int i=1;i<11;i++)
        {
            PlayerPrefs.SetInt("material"+i,Random.Range(0,1000));
            Debug.Log(PlayerPrefs.GetInt("material"+i));
        }
        PlayerPrefs.SetInt("i",0);
        canvas1.SetActive(true);
        StartCoroutine(dunnowhy());
    }

    IEnumerator dunnowhy()
    {
        yield return new WaitForSeconds(0.12f);
        canvas2.SetActive(false);
    }
}
