using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource taskComplete;

    public AudioClip taskCompleteClip;

    public void TaskComplete()
    {
        taskComplete.clip = taskCompleteClip;
        taskComplete.PlayOneShot(taskComplete.clip);
    }


}
