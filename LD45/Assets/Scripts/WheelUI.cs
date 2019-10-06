using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelUI : MonoBehaviour
{
    public GameObject wheel;
    GameObject interactableobject;
    [HideInInspector]
    public bool trans, color, fullcolor;
    [HideInInspector]
    public int touchiteratorCount = 0;
    [HideInInspector]
    public int watchiteratorCount = 0;
    [HideInInspector]
    public int listeniteratorCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveWheel(GameObject interactable)
    {
        interactableobject = interactable;
        wheel.SetActive(true);
    }

    public void DisableWheel()
    {
        StartCoroutine(Disable());
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(2);
        wheel.SetActive(false);
    }

    public void Watching()
    {
        interactableobject.GetComponent<Watching>().OnWatch();
    }

    public void Touching()
    {
        interactableobject.GetComponent<Watching>().OnTouch();
    }

    public void Listening()
    {
        interactableobject.GetComponent<Watching>().OnListen();
    }
}
