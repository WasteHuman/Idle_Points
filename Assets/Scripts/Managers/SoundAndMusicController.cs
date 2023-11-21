using UnityEngine;
using UnityEngine.UI;

public class SoundAndMusicController : MonoBehaviour
{
    public GameObject music;
    public Sprite musicOn;
    public Sprite musicOff;
    public bool musicEnabled = true;

    public GameObject sound;
    public Sprite soundOn;
    public Sprite soundOff;
    public bool soundEnabled = true;

    Image image;

    public bool SoundEnabled { get { return soundEnabled; } set { SetSounds(value); } }
    public bool MusicEnabled { get { return musicEnabled; } set { SetMusic(value); } }

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetSounds(bool enabled)
    {
        if (enabled)
        {
            AudioListener.volume = 1.0f;
            image.sprite = soundOff;    
        }
        else
        {
            AudioListener.volume = 0.0f;
            image.sprite = soundOn;
        }
        soundEnabled = enabled;
    }

    public void SetMusic(bool enabled)
    {
        if (enabled)
        {
            AudioListener.volume = 1.0f;
            image.sprite = musicOff;
        }
        else
        {
            AudioListener.volume = 0.0f;
            image.sprite = musicOn;
        }
        soundEnabled = enabled;
    }

    public void SwithcSounds()
    {
        SoundEnabled = !SoundEnabled;
    }

    public void SwitchMisic()
    {
        MusicEnabled = !MusicEnabled;
    }
}
