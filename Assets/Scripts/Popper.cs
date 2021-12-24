using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popper : MonoBehaviour
{
    [SerializeField] private AudioClip[] alphabet;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Balloon.BalloonPopped += PlayAudio;
    }

    private void DisEnable()
    {
        Balloon.BalloonPopped -= PlayAudio;
    }

    private void PlayAudio(int soundID)
    {
        audioSource.PlayOneShot(alphabet[soundID]);
    }
}
