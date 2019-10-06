using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public ObjectColor[] objects;
    public ShadowsLight[] allLights;
    Color[] colors, colorsRed;
    int count;
    int lightcount;
    public Color mono;
    void Start()
    {
        lightcount = allLights.Length;
        count = objects.Length;
        colors = new Color[count];
        colorsRed = new Color[count];
        SaveParams();
        MonoParams();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SaveParams();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetParams();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SetRedParams();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            MonoParams();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SetShadows();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SetTransparent();
        }
    }

    public void SaveParams()
    {
        for(int i=0; i < count; i++)
        {
            colors[i] = objects[i].gameObject.GetComponent<MeshRenderer>().material.color;
            colorsRed[i] = new Color(colors[i].r, 0, 0);
        }
    }

    public void MonoParams()
    {
        for (int i = 0; i < count; i++)
        {
            objects[i].gameObject.GetComponent<MeshRenderer>().material.color = mono;
        }
    }

    public void SetParams()
    {
        for (int i = 0; i < count; i++)
        {
            objects[i].SetColorFull(colors[i]);
        }
    }

    public void SetRedParams()
    {
        for (int i = 0; i < count; i++)
        {
            objects[i].SetColorRed(colorsRed[i]);
        }
    }

    public void SetShadows()
    {
        for (int i = 0; i < lightcount; i++)
        {
            allLights[i].VisionShadows();
        }
    }

    public void SetTransparent()
    {
        for (int i = 0; i < count; i++)
        {
            objects[i].TransparentObject();
        }
    }
}
