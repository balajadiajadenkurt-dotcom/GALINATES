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

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // 🎵 Play background music automatically
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // 🔊 GENERIC SFX PLAYER
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

    // ✅ CORRECT ANSWER
    public void PlayCorrect()
    {
        PlaySFX(correctSound);
    }

    // ❌ WRONG ANSWER
    public void PlayWrong()
    {
        PlaySFX(wrongSound);
    }

    // 🗑️ TRASHCAN OPEN
    public void PlayTrashcan()
    {
        PlaySFX(trashcanSound);
    }
}