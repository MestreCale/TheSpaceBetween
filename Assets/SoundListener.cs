using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundListener : MonoBehaviour
{
    public AudioSource limboMusic;
    public AudioSource hellMusic;

    private AudioSource playing;

    private void Awake()
    {
        PlayerStatus.OnPlayerChangeLocation += OnLocationChange;

    }

    private void Start()
    {
    }

    private void OnDestroy()
    {
        PlayerStatus.OnPlayerChangeLocation -= OnLocationChange;
    }

    private void OnLocationChange(Location location)
    {
        switch (location)
        {
            case Location.Hell:
                if(playing) playing.Stop();
                
                hellMusic.Play();
                playing = hellMusic;
               
                break;
            case Location.Limbo:
                if(playing) playing.Stop();
                
                limboMusic.Play();
                playing = limboMusic;
                
                break;
            
        }
    }

}
