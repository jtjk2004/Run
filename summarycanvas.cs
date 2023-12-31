using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class summarycanvas : MonoBehaviour
{
    public GameObject pullcanvas, thiscanvas, circle,image,dude,coin,coin2,back,nextt,maincanvas,summaryimage,skip,ui,outward,click;
    public GameObject[] ii;
    public Sprite bl,bd,pl,pd,yl,yd,coinsprite,a,b,c;
    public Image dudes;
    public AudioSource dismiss, magicalsummon;
    private bool once, agate;
    // Start is called before the first frame update
    void Start()
    {
        agate = true;
    }

    void OnEnable()
    {
        skip.SetActive(false);
        magicalsummon.enabled = false;
        dismiss.enabled = false;
        outward.SetActive(false);
        summaryimage.SetActive(false);
        coin.SetActive(false);
        coin2.SetActive(false);
        nextt.SetActive(false);
        back.SetActive(false);
        once = true;
        circle.transform.localScale = new Vector3(1,1,1);
        image.SetActive(false);
        if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))>909)
        {
            dude.SetActive(true);
            molywelee();
        }
        else
        {
            dude.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("char")==1)
        {
            if(circle.transform.localScale.x<21)
            {
                circle.transform.localScale += new Vector3(0.6f,0.6f,0f);
                if(circle.transform.localScale.x>20)
                {
                    dismiss.enabled = false;
                    pullcanvas.SetActive(false);
                    nextt.SetActive(true);
                    image.SetActive(true);
                    dismiss.enabled = true;
                }
            }
            else
            {
                if(circle.GetComponent<Image>().color.a>0)
                {
                    var tempColor = circle.GetComponent<Image>().color;
                    tempColor.a = tempColor.a - 0.1f;
                    circle.GetComponent<Image>().color = tempColor;
                }
                if(circle.GetComponent<Image>().color.a<0.2f)
                {
                    if(PlayerPrefs.GetInt("pull")==10)
                    {
                        skip.SetActive(true);
                    }
                    else
                    {
                        skip.SetActive(false);
                    }
                }
            }
        }
        else
        {
            if(once)
            {
                nextt.SetActive(true);
                circle.SetActive(false);
                image.SetActive(true);
                coin2.SetActive(true);
                coin.SetActive(false);
                StartCoroutine(coinssss());
                once = false;
                if(PlayerPrefs.GetInt("pull")==10)
                {
                    skip.SetActive(true);
                }
                else
                {
                    skip.SetActive(false);
                }
            }
        }
        if(PlayerPrefs.GetInt("pull")==1)
        {
            nextt.SetActive(false);
            back.SetActive(true);
        }
    }

    IEnumerator coinssss()
    {
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(shardoutward());
        coin2.SetActive(false);
        coin.SetActive(true);
    }

    public void next()
    {
        click.SetActive(false);
        click.SetActive(true);
        if(PlayerPrefs.GetInt("i")==10)
        {
            summaryimage.SetActive(true);
            for(int i=1;i<11;i++)
            {
                if(PlayerPrefs.GetInt("material"+i)<910)
                {
                    ii[i-1].GetComponent<Image>().sprite = coinsprite;
                }
                else if(PlayerPrefs.GetInt("material"+i)>909 && PlayerPrefs.GetInt("material"+i)<960)
                {
                    ii[i-1].GetComponent<Image>().sprite = bl;
                }
                else if(PlayerPrefs.GetInt("material"+i)>989)
                {
                    ii[i-1].GetComponent<Image>().sprite = yl;
                }
                else
                {
                    ii[i-1].GetComponent<Image>().sprite = pl;
                }
            }
            skip.SetActive(false);
            nextt.SetActive(false);
            back.SetActive(true);
        }
        else
        {    
            ui.SetActive(true);
            pullcanvas.SetActive(true);
            thiscanvas.SetActive(false);
        }
    }

    void molywelee()
    {
        if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))<960)
        {
            dudes.sprite = bd;
        }
        else if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))>989)
        {
            dudes.sprite = yd;
        }
        else
        {
            dudes.sprite = pd;
        }
        StartCoroutine(Tolight());
    }
    IEnumerator Tolight()
    {
        yield return new WaitForSeconds(1.6f);
        StartCoroutine(shardoutward());
        if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))<960)
        {
            dudes.sprite = bl;
        }
        else if(PlayerPrefs.GetInt("material"+PlayerPrefs.GetInt("i"))>989)
        {
            dudes.sprite = yl;
        }
        else
        {
            dudes.sprite = pl;
        }
    }

    //all permanent saves are done here
    public void bacccck()
    {
        if(agate)
        {
            click.SetActive(false);
            click.SetActive(true);
            agate = false;
            StartCoroutine(backwait());
        }
    }

    public void skipp()
    {
        click.SetActive(false);
        click.SetActive(true);
        summaryimage.SetActive(true);
            for(int i=1;i<11;i++)
            {
                if(PlayerPrefs.GetInt("material"+i)<910)
                {
                    ii[i-1].GetComponent<Image>().sprite = coinsprite;
                }
                else if(PlayerPrefs.GetInt("material"+i)>909 && PlayerPrefs.GetInt("material"+i)<960)
                {
                    ii[i-1].GetComponent<Image>().sprite = bl;
                }
                else if(PlayerPrefs.GetInt("material"+i)>989)
                {
                    ii[i-1].GetComponent<Image>().sprite = yl;
                }
                else
                {
                    ii[i-1].GetComponent<Image>().sprite = pl;
                }
            }
            skip.SetActive(false);
            nextt.SetActive(false);
            back.SetActive(true);
    }

    IEnumerator shardoutward()
    {
        magicalsummon.enabled = false;
        outward.SetActive(true);
        outward.GetComponent<Image>().sprite = a;
        magicalsummon.enabled = true;
        yield return new WaitForSeconds(0.03f);
        outward.GetComponent<Image>().sprite = b;
        yield return new WaitForSeconds(0.03f);
        outward.GetComponent<Image>().sprite = c;
    }

    IEnumerator backwait()
    {
        yield return new WaitForSeconds(0.1f);
        agate = true;
        pullcanvas.SetActive(false);
        maincanvas.SetActive(true);
        thiscanvas.SetActive(false);
    }
}
