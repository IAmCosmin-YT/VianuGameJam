using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    [SerializeField] AudioSource dieAudio;

    public void PlayDieAudio()
    {
        dieAudio.Play();
    }
}
