using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            SceneManager.LoadScene("Dev");
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
    }
}
