using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager: MonoBehaviour
{
    public AudioSource source;

    public void PlaySound(AudioClip clip){
        source.clip = clip;
        source.Play();
        
    }

}