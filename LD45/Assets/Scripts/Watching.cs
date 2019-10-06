using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watching : MonoBehaviour
{
    public WheelUI wheelUI;
    public GameObject child;
    bool watch, listen, touch;
    public ObjectPool pool;
    int iterator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnWatch()
    {
        if (!watch)
        {
            watch = true;
            wheelUI.watchiteratorCount++;
            wheelUI.PlayWinSound();
            Debug.Log(wheelUI.watchiteratorCount + "watching");
            if (wheelUI.watchiteratorCount > 3)
            {
                if (!wheelUI.color)
                {
                    pool.SetRedParams();
                    wheelUI.trans = true;
                    Debug.Log("SetRed");
                }
            }
            if (wheelUI.watchiteratorCount > 7)
            {
                if (!wheelUI.fullcolor)
                {
                    pool.SetParams();
                    wheelUI.trans = true;
                    Debug.Log("SetRed");
                }
            }
        }
    }

    public void OnTouch()
    {
        if(child != null && !touch)
        {
            child.SetActive(true);
            touch = true;            
            if (child.tag == "LightTag")
            {
                wheelUI.touchiteratorCount++;
                pool.SetShadows();
                wheelUI.PlayWinSound();
            }
            else
            {
                wheelUI.PlayWinSound();
                wheelUI.touchiteratorCount++;
                Debug.Log(wheelUI.touchiteratorCount + "touching");
                if(wheelUI.touchiteratorCount > 3)
                {
                    if (!wheelUI.trans)
                    {
                        pool.SetTransparent();
                        wheelUI.trans = true;
                        Debug.Log("SetTransparent");
                    }
                }
            }
        }
    }

    public void OnListen()
    {
        if (GetComponent<AudioSource>())
        {
            if (this.tag == "beat")
            {
                GetComponent<AudioSource>().Play();
            }
            if (!listen)
            {
                listen = true;
                wheelUI.listeniteratorCount++;
                if (wheelUI.listeniteratorCount == 1)
                {
                    GetComponent<AudioSource>().Play();
                }
                if (wheelUI.listeniteratorCount == 2)
                {
                    GetComponent<AudioHighPassFilter>().enabled = false;
                    GetComponent<AudioLowPassFilter>().enabled = false;
                    StartCoroutine(wheelUI.Music());
                }
            }
        }
    }

    private void OnMouseEnter()
    {
        wheelUI.ActiveWheel(this.gameObject);
    }

    private void OnMouseExit()
    {
        wheelUI.DisableWheel();
    }
}
