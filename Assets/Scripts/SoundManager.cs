using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
    }
    
    public void AdjustVolume(float volume)
    {
        float clampedVolume = Math.Clamp(volume, 0, 1);
        _audioSource.volume = clampedVolume;
        PlayerPrefs.SetFloat("SoundVolume", Math.Clamp(clampedVolume, 0, 1));
    }
}