using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] StudioEventEmitter _onClick;
    public void Menu()
    {
        _onClick.Play();
        SceneManager.LoadScene("Menu");
    }
}
