using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private SoundManager _soundManager;
    [SerializeField]
    private Slider _slider;
    
    private void Start()
    {
        _soundManager = FindAnyObjectByType<SoundManager>();
        _slider.value = PlayerPrefs.GetFloat("SoundVolume", 0.5f);
    }

    public void AdjustVolume(float value)
    {
        _soundManager.AdjustVolume(value);
    }
}