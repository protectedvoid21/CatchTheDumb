using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AdjustVolume(float volume)
    {
        float clampedVolume = Math.Clamp(volume, 0, 1);
        _audioSource.volume = clampedVolume;
        PlayerPrefs.SetFloat("SoundVolume", Math.Clamp(clampedVolume, 0, 1));
    }
}