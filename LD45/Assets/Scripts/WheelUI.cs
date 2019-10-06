using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelUI : MonoBehaviour
{

    public GameUI game;
    public GameObject sound;
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
        if (wheel.activeSelf)
        {
            yield return new WaitForSeconds(5);
            wheel.SetActive(false);
        }
    }

    public IEnumerator Music()
    {
        yield return new WaitForSeconds(15);
    }

    public void Watching()
    {
        interactableobject.GetComponent<Watching>().OnWatch();
        if(touchiteratorCount > 8 && watchiteratorCount > 8)
        {
            game.SetWin();
        }
    }

    public void Touching()
    {
        if (touchiteratorCount > 8 && watchiteratorCount > 8)
        {
            game.SetWin();
        }
        interactableobject.GetComponent<Watching>().OnTouch();
    }

    public void Listening()
    {
        interactableobject.GetComponent<Watching>().OnListen();
    }
    public void PlayWinSound()
    {
        GetComponent<AudioSource>().Play();
    }
}
