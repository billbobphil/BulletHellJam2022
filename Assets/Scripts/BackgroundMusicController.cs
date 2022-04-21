using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip passiveTrack;
    public AudioClip actionTrack;
    private AudioSource _musicAudioSource;

    private void Awake()
    {
        _musicAudioSource = GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>();
        SwitchToPassiveTrack();
    }

    public void SwitchToPassiveTrack()
    {
        if (_musicAudioSource.clip != passiveTrack)
        {
            _musicAudioSource.Stop();
            _musicAudioSource.clip = passiveTrack;
            _musicAudioSource.Play();    
        }
    }

    public void SwitchToActionTrack()
    {
        if (_musicAudioSource.clip != actionTrack)
        {
            _musicAudioSource.Stop();
            _musicAudioSource.clip = actionTrack;
            _musicAudioSource.Play();
    
        }
    }
}
