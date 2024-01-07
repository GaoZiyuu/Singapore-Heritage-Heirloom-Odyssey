/* 
 * Author : Gao Ziyu
 * Date: 6/01/2024
 * Description: Audio Manager for the sound effect used in the game
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /// <summary>
    /// variables for audiosource
    /// </summary>
    public AudioSource taskComplete;
    public AudioSource phoneRing;
    public AudioSource magicalSound;

    /// <summary>
    /// audio clips
    /// </summary>
    public AudioClip taskCompleteClip;
    public AudioClip phoneRingClip;
    public AudioClip magicalSoundClip;

    /// <summary>
    /// sound effect that plays when task is completed
    /// </summary>
    public void TaskComplete()
    {
        taskComplete.clip = taskCompleteClip;
        taskComplete.PlayOneShot(taskComplete.clip);
    }

    /// <summary>
    /// ringing sound effect for task02-task03
    /// </summary>
    public void Ring()
    {
        phoneRing.Play();
    }

    /// <summary>
    /// stop playing ringing song effect
    /// </summary>
    public void StopRing()
    {
        phoneRing.Stop();
    }

    /// <summary>
    /// plays the magical sound effect for the time travelling part
    /// </summary>
    public void PlayMagicSound()
    {
        magicalSound.Play();
    }

}
