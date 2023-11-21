using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //Массив звуков
    public Sound[] sounds;

    //Название фоновой музыки
    public string mainTheme;

    void Awake()
    {
        //Создание AudioSourse
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;

            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
        }
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == soundName);

        if (s == null)
        {
            Debug.LogError(soundName + " данный звук не найден!");
            return;
        }

        s.audioSource.Play();
    }
}
