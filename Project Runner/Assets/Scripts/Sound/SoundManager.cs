using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [Header("--- Audio Source ---")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource walkSource;
    public AudioSource runSource;

    [Header("--- Music ---")]
    public AudioClip cyberpunk;

    [Header("--- PlayerSFX ---")]
    public AudioClip sfxAttack;
    public AudioClip sfxWalk;
    public AudioClip sfxRun;


    public void PlaySfx(AudioClip clip)
    {
        if (sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayWalk(AudioClip clip)
    {
        walkSource.PlayOneShot(clip);
    }

    public void PlayRun(AudioClip clip)
    {
        runSource.PlayOneShot(clip);
    }
    
}
