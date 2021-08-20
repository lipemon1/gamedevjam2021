using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class MenuBGM : MonoBehaviour
{
    public static MenuBGM Instance { get; set; }

    public StudioEventEmitter _menuEmitter;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
        
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        _menuEmitter.Play();
    }

    public void StopMenuBGM()
    {
        _menuEmitter.Stop();
        Destroy(this.gameObject);
    }
}
