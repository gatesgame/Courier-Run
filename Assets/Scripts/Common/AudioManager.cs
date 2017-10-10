using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance = null;
    public AudioSource AudioSource;
    public AudioClip JumpAudio;
    public AudioClip SpeedBoostAudio;
    public AudioClip DieAudio;
    public AudioClip GetEnergyAudio;
    public AudioClip GetCoinAudio;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if(Instance!= this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void PlayAudioJump()
    {
        AudioSource.PlayOneShot(JumpAudio);
    }

    public void PlayAudioSpeedBoost()
    {
        AudioSource.PlayOneShot(SpeedBoostAudio);
    }

    public void PlayDieAudio()
    {
        AudioSource.PlayOneShot(DieAudio);
    }

    public void PlayGetCoinAudio()
    {
        AudioSource.PlayOneShot(GetCoinAudio);
    }

    public void PlayAudiogetEnergy()
    {
        AudioSource.PlayOneShot(GetEnergyAudio);
    }

    public void SettingAudio()
    {
        if(PlayerPrefs.GetString("Audio") == "On")
        {
            AudioSource.mute = true;
            PlayerPrefs.SetString("Audio", "Off");
        }
        else
        {
            AudioSource.mute = false;
            PlayerPrefs.SetString("Audio", "On");
        }
    }
}
