using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;

    public void SetMasterVolume(float value)
    {
        _masterMixer.SetFloat("volume_Master", FromSliderToLog(value));
    }
    
    public void SetSFXVolume(float value)
    {
        _masterMixer.SetFloat("volume_SFX", FromSliderToLog(value));
    }
    
    public void SetAmbiantVolume(float value)
    {
        _masterMixer.SetFloat("volume_Ambiant", FromSliderToLog(value));
    }
    
    public void SetMusicVolume(float value)
    {
        _masterMixer.SetFloat("volume_Music", FromSliderToLog(value));
    }

    private float FromSliderToLog(float value)
    {
        return (Mathf.Log10(value) * 20);
    }
}
