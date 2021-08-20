using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] StudioEventEmitter _onClick;
    public void Menu()
    {
        _onClick.Play();
        SceneManager.LoadScene("Menu");
    }
}
