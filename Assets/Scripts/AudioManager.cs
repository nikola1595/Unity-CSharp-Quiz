using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable()]
public struct SoundParameters
{
    [Range(0,1)]
    public float Volume;
    [Range(-3, 3)]
    public float Pitch;
    public bool Loop;
}
[Serializable()]
public class Sound
{
    [SerializeField] string name = String.Empty;
    public string Name { get { return name; } }

    [SerializeField] AudioClip clip = null;
    public AudioClip Clip { get { return clip; } }

    [SerializeField] SoundParameters parameters;
    public SoundParameters Parameters { get { return parameters; } }

    [HideInInspector]
    public AudioSource Source = null;


    public void Play()
    {
        Source.clip = Clip;

        Source.volume = Parameters.Volume;
        Source.pitch = Parameters.Pitch;
        Source.loop = Parameters.Loop;

        Source.Play();
    }


    public void Stop()
    {
        Source.Stop();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    [SerializeField] Sound[] sounds = null;
    [SerializeField] AudioSource sourcePrefab = null;

  //  [SerializeField] string startupTrack = String.Empty;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        InitSounds();
    }

    void Start()
    {
        

        /*
        if(string.IsNullOrEmpty(startupTrack) != true)
        {
            PlaySound(startupTrack);
        }
        */
    }



    void InitSounds()
    {
        foreach (var sound in sounds)
        {
            AudioSource source = Instantiate(sourcePrefab, gameObject.transform);
            source.name = sound.Name;
            sound.Source = source;
        }
    }


    public void PlaySound(string name)
    {
        var sound = GetSound(name);
        if (sound != null)
        {
            sound.Play();
        }
        else
        {
            Debug.LogWarningFormat("Sound by the name {0} is not found", name);
        }
    }


    public void StopSound(string name)
    {
        var sound = GetSound(name);
        if (sound != null)
        {
            sound.Stop();
        }
        else
        {
            Debug.LogWarningFormat("Sound by the name {0} is not found", name);
        }
    }


    Sound GetSound(string name)
    {
        foreach (var sound in sounds)
        {
            if(sound.Name == name)
            {
                return sound;
            }
        }
        return null;
    }

}
