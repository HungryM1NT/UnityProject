using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject menuPaused;
    bool isMenuPaused = false;

    private void Start()
    {
        menuPaused.SetActive(false);
    }

    private void Update()
    {
        ActiveMenu();
    }

    void ActiveMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuPaused = !isMenuPaused;
        }

        if(isMenuPaused)
        {
            menuPaused.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            menuPaused.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ContinuePressed()
    {
        isMenuPaused = !isMenuPaused;
    }
}
