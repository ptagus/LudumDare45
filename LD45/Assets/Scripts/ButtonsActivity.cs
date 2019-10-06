using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsActivity : MonoBehaviour
{
    public WheelUI wheelUI;
    public GameObject wheel;
    public void Watch()
    {
        wheel.SetActive(false);
        wheelUI.Watching();
    }

    public void Touch()
    {
        wheel.SetActive(false);
        wheelUI.Touching();
    }

    public void Listen()
    {
        wheel.SetActive(false);
        wheelUI.Listening();
    }
}
