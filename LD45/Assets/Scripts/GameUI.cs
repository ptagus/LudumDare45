using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Win;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void EndPause()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void SetWin()
    {
        Time.timeScale = 0;
        Win.SetActive(true);
    }
}
