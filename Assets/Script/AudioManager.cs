using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource taskComplete;
    public AudioSource phoneRing;
    public AudioSource magicalSound;

    public AudioClip taskCompleteClip;
    public AudioClip phoneRingClip;
    public AudioClip magicalSoundClip;
    public void TaskComplete()
    {
        taskComplete.clip = taskCompleteClip;
        taskComplete.PlayOneShot(taskComplete.clip);
    }

    public void Ring()
    {
        phoneRing.Play();
    }

    public void StopRing()
    {
        phoneRing.Stop();
    }

    public void PlayMagicSound()
    {
        magicalSound.Play();
    }

}
