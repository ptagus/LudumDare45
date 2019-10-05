using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public ObjectColor[] objects;
    Color[] colors, colorsRed;
    int count;
    public Color mono;
    void Start()
    {
        count = objects.Length;
        colors = new Color[count];
        colorsRed = new Color[count];
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
            //objects[i].gameObject.GetComponent<MeshRenderer>().material.color = colors[i];
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
}
