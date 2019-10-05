using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VisionType
{
    Mono,
    MonoAndLight,
    RedColor,
    FullColor
}

public class VisionController : MonoBehaviour
{
    VisionType vType;
    void Start()
    {
        vType = VisionType.Mono;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UpgradeVision(vType);
        }
    }

    public VisionType UpgradeVision(VisionType type)
    {
        type++;
        return type;
    }

    public void MonoVision()
    {
        
    }
}
