using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    public static event Action<AudioClip> PlaySoundEffect;
    // Start is called before the first frame update


    // Update is called once per frame
    public static void OnPlaySoundEffect(AudioClip clip) => PlaySoundEffect?.Invoke(clip);
}
