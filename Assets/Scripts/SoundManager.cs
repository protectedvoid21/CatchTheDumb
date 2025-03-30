using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void AdjustVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}