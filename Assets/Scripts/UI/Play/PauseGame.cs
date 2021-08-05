using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject PausePanel;
    [SerializeField] KeyCode _pauseKey;
    [SerializeField] bool _pause;

    void Update()
    {
        if (Input.GetKeyDown(_pauseKey))
            _pause = !_pause;
            
        if(Input.GetKeyDown(_pauseKey) && _pause)
            Pause();
        
        if(Input.GetKeyDown(_pauseKey) && !_pause)
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