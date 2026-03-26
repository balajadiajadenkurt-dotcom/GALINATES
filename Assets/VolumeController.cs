using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        // Load saved volume (default = 1)
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        volumeSlider.value = savedVolume;

        AudioManager.instance.musicSource.volume = savedVolume;

        // Listen to slider changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioManager.instance.musicSource.volume = volume;
        AudioManager.instance.sfxSource.volume = volume;

        // Save volume
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
