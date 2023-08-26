
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicStart;
    public AudioClip youDiedSFX;
    void Start()
    {
        musicSource.PlayOneShot(musicStart);
        musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }

    public void YouDied()
    {
        musicSource.Stop();
        musicSource.PlayOneShot(youDiedSFX);
    }
}
