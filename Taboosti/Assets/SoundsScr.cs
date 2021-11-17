using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class SoundsScr : MonoBehaviour
{
    public Sound[] Sounds;
    public AudioMixerGroup mixerGroup;
    public AudioMixer Mixer;
    public GameMechanicsScr gameMechanicsScr;
    public ExtraDataHere extradatahere;
    Sound TimerSound;
    void Awake() 
    {
        foreach (Sound s in Sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.loop = false;
            s.source.clip = s.Clip; 
            s.source.outputAudioMixerGroup = mixerGroup; 
        }
        //slider.value = volumelock;
        //AudioPLayer.Play(Sounds[1]);
    }

    public void Right()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Right");
        if(s != null)
            s.source.PlayOneShot(s.source.clip);
            
    }
    public void Wrong()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Wrong");
        if(s != null)
            s.source.PlayOneShot(s.source.clip);
    }
    public void Pass()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Pass");
        if(s != null)
            s.source.PlayOneShot(s.source.clip);
    }
    public void Winning()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Winning");
        if(s != null)
            s.source.PlayOneShot(s.source.clip);
    }
    public void Starting()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Start");
        if(s != null)
            s.source.PlayOneShot(s.source.clip);
    }
    public void Timer()
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == "Timer");
        if(s != null)
        {
            s.source.Play();
            TimerSound = s;
        }  
    }
    void Update() 
    {
        if(TimerSound != null)
        {
            if(gameMechanicsScr.PauseWindow.activeSelf)
                TimerSound.source.Pause();
            else
                TimerSound.source.UnPause();
        }
    }
    public void Mute()
    {   
        if(extradatahere.dataForSaving.Sound)
            {
                Mixer.SetFloat("Volume",0);
            }
        else
            {
                Mixer.SetFloat("Volume",-80);
            }
        
    }

}
