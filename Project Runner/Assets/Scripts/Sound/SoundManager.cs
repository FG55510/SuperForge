using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager INSTANCE;
    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
    }
    [Header("--- Audio Source ---")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource playerSource;
    public AudioSource inimigoSource;

    [Header("--- Music ---")]
    public AudioClip cyberpunk;

    [Header("--- PlayerSFX ---")]
    public AudioClip sfxAttack;
    public AudioClip sfxWalk;
    public AudioClip sfxRun;

    [Header("--- InimigoRoboSFX ---")]
    public AudioClip sfxRoboAtack;
    public AudioClip sfxRoboWalk;

    [Header("--- InimigoRoboSFX ---")]
    public AudioClip sfxAgentAtack;
    public AudioClip sfxAgentWalk;


    private void Start()
    {
        musicSource.clip = cyberpunk;
        musicSource.Play();
    }
    public void PlayAtack()
    {
        playerSource.PlayOneShot(sfxAttack);
  
    }

    public void PlayWalk()
    {
        playerSource.PlayOneShot(sfxWalk);
    }

    public void PlayRun()
    {
        playerSource.PlayOneShot(sfxRun);
    }

    public void PlayEnemyRoboAtack()
    {
        inimigoSource.PlayOneShot(sfxRoboAtack);
    }
    
    public void StopPlayingAtack()
    {
        playerSource.Stop();
    }

    public void ConfigureVFX()
    {
        playerSource.Play();
    }
}
