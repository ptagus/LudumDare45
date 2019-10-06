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
            Debug.Log(wheelUI.watchiteratorCount + "watching");
            if (wheelUI.watchiteratorCount > 2)
            {
                if (!wheelUI.color)
                {
                    pool.SetRedParams();
                    wheelUI.trans = true;
                    Debug.Log("SetRed");
                }
            }
            if (wheelUI.watchiteratorCount > 5)
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
                pool.SetShadows();
            }
            else
            {
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
