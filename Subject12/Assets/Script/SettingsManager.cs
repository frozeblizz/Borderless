using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider effectVolumeSlider;

    public AudioSource musicSource;
    public AudioSource effectSource;

    public GameSettings gameSettings;

    int changeCount;

    private void Start()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("music");
        effectVolumeSlider.value = PlayerPrefs.GetFloat("effect");
    }

    void OnEnable()
    {
        gameSettings = new GameSettings();

        musicVolumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
        effectVolumeSlider.onValueChanged.AddListener(delegate { OnEffectChange(); });
    }

    public void OnVolumeChange()
    {
        musicSource.volume = gameSettings.musicVolume =  musicVolumeSlider.value;
        PlayerPrefs.SetFloat("music", musicVolumeSlider.value);  
    }

    public void OnEffectChange()
    {      
        effectSource.volume = gameSettings.effectVolume = effectVolumeSlider.value;       
        PlayerPrefs.SetFloat("effect", effectVolumeSlider.value);
        if(changeCount>0)
        {
            effectSource.Play();
        }         
        changeCount++;
    }
}
