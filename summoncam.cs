using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class summoncam : MonoBehaviour
{
    public Color one, two, three;
    public Material aa, bb, cc;
    public GameObject display1, display2, cameras, particle, summarycanvas, thiscanvas, circle,ui;
    [SerializeField]
    private Vector3[] positions;
    public AudioSource summonmusic, ching;
    public int index,a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        PlayerPrefs.SetInt("i",PlayerPrefs.GetInt("i")+1);
        index = 0;
        Debug.Log(PlayerPrefs.GetInt("i"));
        if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))<910)
        {
            PlayerPrefs.SetInt("char",0);
            StartCoroutine(weedeedee());
        }
        else
        {
            ui.SetActive(false);
            circle.SetActive(true);
            PlayerPrefs.SetInt("char",1);
        }
        StartCoroutine(dada());
        cameras.GetComponent<Camera>().backgroundColor = one;
        display1.GetComponent<SpriteRenderer>().color = one;
        display2.GetComponent<SpriteRenderer>().color = one;
        circle.GetComponent<Image>().color = one;
        particle.GetComponent<ParticleSystemRenderer>().material = aa;
        cameras.transform.position = new Vector3(0,0,-5);
    }

    // Update is called once per frame
    void Update()
    {
        animate();
    }

    void animate()
    {
        if(index==0)
        {
            cameras.transform.position = Vector3.MoveTowards(cameras.transform.position,positions[index],0.5f*a);
        }
        else if(index==1)
        {
            cameras.transform.position = Vector3.MoveTowards(cameras.transform.position,positions[index],0.05f*a);
        }
        else if(index==2)
        {
            if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))>959)
            {
                cameras.transform.position = Vector3.MoveTowards(cameras.transform.position,positions[index],0.5f*a);
            }
            else
            {
                summarycanvas.SetActive(true);
            }
        }
        else if(index==3)
        {
            cameras.transform.position = Vector3.MoveTowards(cameras.transform.position,positions[index],0.05f*a);
        }
        else if(index==4)
        {
            if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))>989)
            {
                cameras.transform.position = Vector3.MoveTowards(cameras.transform.position,positions[index],0.7f*a);
            }
            else
            {
                summarycanvas.SetActive(true);
            }
        }
        else
        {
            cameras.transform.position = Vector3.MoveTowards(cameras.transform.position,positions[index],0.03f*a);
        }
        if(cameras.transform.position==positions[index])
        {
            if(index==5)
            {
                summarycanvas.SetActive(true);
            }
            if(index<5)
            {
                index++;
            }
            if(index==3)
            {
                ching.pitch = 1.3f;
                cameras.GetComponent<Camera>().backgroundColor = two;
                display1.GetComponent<SpriteRenderer>().color = two;
                display2.GetComponent<SpriteRenderer>().color = two;
                circle.GetComponent<Image>().color = two;
                particle.GetComponent<ParticleSystemRenderer>().material = bb;
            }
            if(index==5)
            {
                ching.pitch = 1.6f;
                cameras.GetComponent<Camera>().backgroundColor = three;
                display1.GetComponent<SpriteRenderer>().color = three;
                display2.GetComponent<SpriteRenderer>().color = three;
                circle.GetComponent<Image>().color = three;
                particle.GetComponent<ParticleSystemRenderer>().material = cc;
            }
        }
    }

    IEnumerator weedeedee()
    {
        yield return new WaitForSeconds(0f);
        summarycanvas.SetActive(true);
        thiscanvas.SetActive(false);
    }

    IEnumerator dada()
    {
        summonmusic.enabled = false;
        ching.enabled = false;
        yield return new WaitForSeconds(0f);
        summonmusic.enabled = true;
        ching.enabled = true;
        ching.pitch = 1f;
    }
}

