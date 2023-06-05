using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarAudioManager : MonoBehaviour 
{
    public AudioSource source;
	public AudioClip FirstPartSound;
    public AudioClip LoopSound;
    bool CanPlay;

    void StartGame()
    {
        source.PlayOneShot(FirstPartSound);
        CanPlay = true;
    }

    void Update()
    {
        if (!source.isPlaying && CanPlay)
        {
            source.clip = LoopSound;
            source.Play();
        }
    }

    void EndGame()
    {
        source.Stop();
        CanPlay = false;
    }
}
