using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer _aMixer;

    public void MuteSound() {
        float currVol;
        _aMixer.GetFloat("MasterVolume", out currVol);
        _aMixer.SetFloat("MasterVolume", -(currVol + 80));
    }
} 
