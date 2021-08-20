using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.UI;

public class VCAControllers : MonoBehaviour
{
    [SerializeField] string _masterPath;
    [SerializeField] Slider _masterSlider;
    FMOD.Studio.VCA _masterVca;
    
    [SerializeField] string _sfxPath;
    [SerializeField] Slider _sfxSlider;
    FMOD.Studio.VCA _sfxVca;
    
    [SerializeField] string _musicPath;
    [SerializeField] Slider _musicSlider;
    FMOD.Studio.VCA _musicVca;
    
    [SerializeField] string _voicePath;
    [SerializeField] Slider _voiceSlider;
    FMOD.Studio.VCA _voiceVca;

    // Start is called before the first frame update
    void Start()
    {
        _masterVca = FMODUnity.RuntimeManager.GetVCA("vca:/" + _masterPath);
        _sfxVca = FMODUnity.RuntimeManager.GetVCA("vca:/" + _sfxPath);
        _musicVca = FMODUnity.RuntimeManager.GetVCA("vca:/" + _musicPath);
        _voiceVca = FMODUnity.RuntimeManager.GetVCA("vca:/" + _voicePath);
        
        StartBar(_masterVca, _masterSlider);
        StartBar(_sfxVca, _sfxSlider);
        StartBar(_musicVca, _musicSlider);
        StartBar(_voiceVca, _voiceSlider);
        
        _masterSlider.onValueChanged.AddListener((value) => UpdateVca(value, _masterVca));
        _sfxSlider.onValueChanged.AddListener((value) => UpdateVca(value, _sfxVca));
        _musicSlider.onValueChanged.AddListener((value) => UpdateVca(value, _musicVca));
        _voiceSlider.onValueChanged.AddListener((value) => UpdateVca(value, _voiceVca));
    }

    private void UpdateVca(float value, VCA vca)
    {
        vca.setVolume(value);
    }

    private void StartBar(VCA vca, Slider vcaSlider)
    {
        float volume = 1f;
        vca.getVolume(out volume);

        vcaSlider.value = volume;
    }
}
