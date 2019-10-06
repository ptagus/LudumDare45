using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColor : MonoBehaviour
{
    [HideInInspector]
    public Color itemColor;
    Material material;
    bool Red, Full, trans;
    bool fullRed = true, fullGreen =true, fullBlue = true;
    float redcolor = 0,greencolor = 0,bluecolor = 0;
    float redcolorspeed = 0.1f;
    float bluecolorspeed = 0.1f;
    float greencolorspeed = 0.1f;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (trans)
        {
            itemColor.a -= Time.deltaTime * 0.1f;
            GetComponent<MeshRenderer>().material.color = itemColor;
            if(itemColor.a <= 0)
            {
                trans = false;
            }
        }
        if (Red)
        {
            redcolor += Time.deltaTime * 0.1f;
            GetComponent<MeshRenderer>().material.color = new Color(redcolor,0,0,1);
            if(redcolor >= itemColor.r)
            {
                Red = false;
                Debug.Log("EndRed" + redcolor);
            }
        }
        if (Full)
        {
            if (redcolor < itemColor.r && fullRed)
            {
                redcolor += Time.deltaTime * redcolorspeed;
                Debug.Log("EndRed" + redcolor);
            }
            else
            {
                fullRed = false;
                redcolorspeed = 0;
            }
            if (greencolor < itemColor.g && fullGreen)
            {
                greencolor += Time.deltaTime * greencolorspeed;
                Debug.Log("Endgreen" + greencolor);
            }
            else
            {
                fullGreen = false;
                redcolorspeed = 0;
            }
            if (bluecolor < itemColor.b && fullBlue)
            {
                bluecolor += Time.deltaTime * bluecolorspeed;
                Debug.Log("Endblue" + bluecolor);
            }
            else
            {
                fullBlue = false;
                redcolorspeed = 0;
            }
            GetComponent<MeshRenderer>().material.color = new Color(redcolor, greencolor, bluecolor);
            if (!fullBlue && !fullGreen && !fullGreen)
            {
                GetComponent<MeshRenderer>().material.color = new Color(itemColor.r, itemColor.g, itemColor.b);
                Full = false;
                Debug.Log("EndFull" + GetComponent<MeshRenderer>().material.color);
            }
        }
    }

    public void SetColorRed(Color redparams)
    {
        itemColor = redparams;
        Debug.Log(redparams.r + "      " + itemColor.r);
        Red = true;
        Debug.Log("SetColorRed");
    }
    public void SetColorFull(Color fullparams)
    {
        itemColor = fullparams;
        Debug.Log(fullparams.r + "      " + itemColor.g + "      " + itemColor.b);
        Full = true;
        Debug.Log("SetColorFull");
    }
    public void TransparentObject()
    {
        itemColor = GetComponent<MeshRenderer>().material.color;
        trans = true;
    }
}
