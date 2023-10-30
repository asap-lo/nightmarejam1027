using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playaudio : MonoBehaviour
{
    // array of audiosources
    
    //make this an array of audio clips
    public AudioSource[] audio;
    
    public void PlayAudio(int i)
    {
        audio[i].Play();
    }
}
