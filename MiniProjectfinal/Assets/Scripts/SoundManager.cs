using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip ExplosionClip;
    public AudioClip playerDeadA;
    public AudioClip bossDeadA;
    public AudioClip bossJumpA;
    public AudioClip piberA;
    public AudioClip iceA;
    public AudioClip inkSound;
    AudioSource ExplosionSource;
    public static SoundManager soundInstance;

    private void Awake()
    {
        if (SoundManager.soundInstance == null)
            SoundManager.soundInstance = this;

    }


    // Use this for initialization
    void Start () {
        ExplosionSource = GetComponent<AudioSource>();
	}
    public void PlaySound()
    {
        if (!Pause.pause)
        {
            ExplosionSource.PlayOneShot(ExplosionClip);

        }
    }
    public void InkSound()
    {
        if (!Pause.pause)
        {
            ExplosionSource.PlayOneShot(inkSound);
        }
    }
    public void PlayerDead() {
        if (!Pause.pause)
        {
            ExplosionSource.PlayOneShot(playerDeadA);
        }
    }

    public void BossJump()
    {
        if (!Pause.pause)
        {
            ExplosionSource.PlayOneShot(bossJumpA);
        }
    }

    public void BossDead()
    {
        if (!Pause.pause)
        {
            ExplosionSource.PlayOneShot(bossDeadA);
        }
    }

    public void Piber()
    {
        if (!Pause.pause)
        {
            ExplosionSource.PlayOneShot(piberA);
        }
    }

    public void Ice()
    {
        if (!Pause.pause)
        {
            ExplosionSource.PlayOneShot(iceA);
        }
    }
}
