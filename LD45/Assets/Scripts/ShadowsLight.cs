using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowsLight : MonoBehaviour
{
    bool castShadows;
    public Light lights;
    float speedintensity = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (castShadows)
        {
            lights.shadowStrength += Time.deltaTime * speedintensity;
            if(lights.shadowStrength > 0.95)
            {
                lights.shadowStrength = 1;
                castShadows = false;
            }
        }
    }

    public void VisionShadows()
    {
        castShadows = true;
    }
}
