using UnityEngine;
using UnityEngine.UI;

public class AudioButtonUI : MonoBehaviour
{
    public Image buttonImage;      // The image on your button
    public Sprite soundOnIcon;     // 🔊 icon
    public Sprite soundOffIcon;    // 🔇 icon

    void Start()
    {
        UpdateIcon();
    }

    // 🔘 THIS WILL SHOW IN BUTTON
    public void ToggleAudio()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleMusic();
            UpdateIcon();
        }
    }

    void UpdateIcon()
    {
        if (AudioManager.instance != null && AudioManager.instance.isMuted)
        {
            buttonImage.sprite = soundOffIcon;
        }
        else
        {
            buttonImage.sprite = soundOnIcon;
        }
    }
}