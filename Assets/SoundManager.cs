using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource SoundSfx;

    public AudioSource SoundBGMusic;

    public SoundType[] sounds;


    //Singleton script for SoundManager Instance
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    //Awake
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    public void PlayOnce(Sounds _sound)
    {
        AudioClip clip = getSoundClip(_sound);
        if (clip != null)
        {
            SoundSfx.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("No clip found for Sound Type");
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType _soundtype =  Array.Find(sounds, s => s.soundType == sound);
        if (_soundtype != null)
            return _soundtype.soundClip;
        return null;
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    ButtonClick,
    PlayerDeath,
    PlayerMove
}
