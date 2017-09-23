
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    public AudioSource AudioSourceMicroInput;
    public float Sensitivity = 100;
    public float Loudness;

    void Start()
    {
        AudioSourceMicroInput = GetComponent<AudioSource>();
        AudioSourceMicroInput.clip = Microphone.Start(null, true, 10, 44100);
        AudioSourceMicroInput.loop = true;

        // lay vi tri mau ban ghi ! Kim soat do tre phat ra am thanh (>x)
        while (!(Microphone.GetPosition("") > 0))
        {
        }
        AudioSourceMicroInput.Play();
    }

    void Update()
    {
        Loudness = GetAveragedVolume() * Sensitivity;
    }

    //lay trung bnh du lieu cua ban ghi
    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        AudioSourceMicroInput.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }

    public void MuteMic()
    {
        AudioSourceMicroInput.mute = true;
    }
}

