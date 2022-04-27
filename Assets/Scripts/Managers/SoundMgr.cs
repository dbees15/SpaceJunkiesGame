using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public static SoundMgr inst;

    private void Awake()
    {
        inst = this;
    }

    //public AudioSource backgroundMusic;
    public AudioSource debrisPickup;
    public AudioSource gameOver;
    public AudioSource playerProjectile;
    public AudioSource enemyDie;
    public AudioSource magnetSound;
    
    //public void PlayBackground()
    //{
    //    backgroundMusic.Play();
    //}

    public void PlayDebris()
    {
        debrisPickup.Play();
    }

    public void PlayMagnet()
    {
        magnetSound.Play();
    }
    public void StopMagnet()
    {
        magnetSound.Stop();
    }

    public void PlayProjectile()
    {
        playerProjectile.Play();
    }

    public void PlayGameOver()
    {
        gameOver.Play();
    }
    public void StopGameOver()
    {
        gameOver.Stop();
    }

    public void PlayEnemyDie()
    {
        enemyDie.Play();
    }


}
