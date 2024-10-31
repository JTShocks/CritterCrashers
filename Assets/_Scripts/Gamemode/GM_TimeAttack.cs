using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_TimeAttack : Gamemode
{

    const float TIME_PER_CHECKPOINT = 2f;

    [SerializeField] AudioClip checkpointReachedSFX;
    void OnEnable()
    {
        CheckpointManager.RacerAdvanced += AddRaceTime;
        EventManager.TimerStop += GameLose;
        
    }



    void OnDisable()
    {
        CheckpointManager.RacerAdvanced -= AddRaceTime;
        EventManager.TimerStop -= GameLose;
        
    }

    void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();

        EventManager.OnTimerStart();
        //EventManager.OnLapUpdate(currentLap);
        Debug.Log("Race Gamemode initialized!");
        //Set the base values for the gamemode
        //Trigger any effects that need to be triggered

        
    }

    public void AddRaceTime(Racer racer)
    {
        Debug.Log("Time Added");
        EventManager.OnTimerUpdate(TIME_PER_CHECKPOINT);
        AudioManager.OnPlaySoundEffect(checkpointReachedSFX);
    }
}
