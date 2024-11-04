using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    void OnEnable()
    {
        AudioManager.PlaySoundEffect += OnPlaySoundEffect;
    }

    void OnDisable()
    {
        AudioManager.PlaySoundEffect -= OnPlaySoundEffect;
    }

    [SerializeField] AudioSource audioSource;

    private void OnPlaySoundEffect(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }


}
