using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] StudioEventEmitter _play;
    [SerializeField] StudioEventEmitter _confirm;
    void Start()
    {
        PlayerPrefs.SetInt("LevelDone", 0);
    }

    public void Play()
    {
        _play.Play();
        MenuBGM.Instance.StopMenuBGM();
        SceneManager.LoadScene("Intro");
    }

    public void Options()
    {
        PlayConfirmSfx();
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        PlayConfirmSfx();
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        PlayConfirmSfx();
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    void PlayConfirmSfx()
    {
        _confirm.Play();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            SceneManager.LoadScene("Dev");
        }

        if (Input.GetKey(KeyCode.I))
        {
            SceneManager.LoadScene("Intro");
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Level_1");
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Level_2");
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Level_3");
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("Level_4");
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("Level_5");
        }

        if (Input.GetKey(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("Level_6");
        }

        if (Input.GetKey(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("Level_7");
        }

        if (Input.GetKey(KeyCode.Alpha8))
        {
            SceneManager.LoadScene("Level_8");
        }
    }
}
