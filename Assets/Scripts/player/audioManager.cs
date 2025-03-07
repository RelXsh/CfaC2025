using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManaer : MonoBehaviour
{
    public AudioSource sfx;

    public AudioClip apple;
    public AudioClip answer;
    public AudioClip crokensky;

    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}
