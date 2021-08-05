using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PausePanel;
    bool _pause;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
            _pause = !_pause;
            
        if(Input.GetButtonDown("Pause") && _pause)
            Pause();
        
        if(Input.GetButtonDown("Pause") && !_pause)
            Resume();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}