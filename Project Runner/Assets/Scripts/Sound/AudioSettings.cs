using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private bool isPlayingSFX = false;

    private void Start()
    {
        if(PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetSFXVolume();
            SetMusicVolume();
        }

    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
        if (!isPlayingSFX)
        {
            SoundManager.INSTANCE.ConfigureVFX();
            isPlayingSFX = true;
        }
        CancelInvoke();
        Invoke("StopPlayingVfx", 1f);

    }
    
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolume () 
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
        SetSFXVolume();
    }

    private void StopPlayingVfx()
    {
        SoundManager.INSTANCE.StopPlayingAtack();
        isPlayingSFX = false;
    }
}
