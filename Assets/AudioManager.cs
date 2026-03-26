using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip backgroundMusic;

    [Header("Sound Effects")]
    public AudioClip clickSound;
    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioClip trashcanSound;

    [Header("Settings")]
    public bool isMuted = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Load saved volume
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSource.volume = savedVolume;

        // Load mute state
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        musicSource.mute = isMuted;

        // Play music
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // 🎵 TOGGLE MUSIC ON/OFF
    public void ToggleMusic()
    {
        isMuted = !isMuted;

        if (musicSource != null)
        {
            musicSource.mute = isMuted;
        }

        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    // 🔊 PLAY SFX
    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    // 🔘 BUTTON CLICK
    public void PlayClick()
    {
        PlaySFX(clickSound);
    }

    // ✅ CORRECT
    public void PlayCorrect()
    {
        PlaySFX(correctSound);
    }

    // ❌ WRONG
    public void PlayWrong()
    {
        PlaySFX(wrongSound);
    }

    // 🗑️ TRASHCAN
    public void PlayTrashcan()
    {
        PlaySFX(trashcanSound);
    }
}