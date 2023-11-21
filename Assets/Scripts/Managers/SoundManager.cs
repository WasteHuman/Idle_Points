using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager S;
    public AudioClip clickClip;

    private Vector3 cameraPos;

    void Awake()
    {
        S = this;

        cameraPos = Camera.main.transform.position;
    }

    public void PlayClip(AudioClip clip)
    {
        if (PlayerPrefs.GetString("Sounds") == "On")
        {
            AudioSource.PlayClipAtPoint(clip, cameraPos);
        }
    }

    public void PlayClickClip()
    {
        PlayClip(clickClip);
    }
}
