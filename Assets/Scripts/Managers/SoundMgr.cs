using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public AudioSource bgMusic;
    //public AudioSource debrisPickup;
    
    public void PlayBackground()
    {
        bgMusic.Play();
    }
    
}
