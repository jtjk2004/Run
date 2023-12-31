using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class whichdude : MonoBehaviour
{
    public Image image;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        
    }

    void OnEnable()
    {
        molywelee();
    }
    public void molywelee()
    {
        if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))<960)
        {
            image.sprite = canvas.GetComponent<summarycanvas>().bd;
        }
        else if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))>989)
        {
            image.sprite = canvas.GetComponent<summarycanvas>().yd;
        }
        else
        {
            image.sprite = canvas.GetComponent<summarycanvas>().pd;
        }
        StartCoroutine(Tolight());
    }
    IEnumerator Tolight()
    {
        
        yield return new WaitForSeconds(1.1f);
        if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))<960)
        {
            image.sprite = canvas.GetComponent<summarycanvas>().bl;
        }
        else if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))>989)
        {
            image.sprite = canvas.GetComponent<summarycanvas>().yl;
        }
        else
        {
            image.sprite = canvas.GetComponent<summarycanvas>().pl;
        }
    }
}
