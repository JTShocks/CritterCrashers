using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System;


public class GM_Race : Gamemode
{
    public const int TOTAL_LAPS = 3;

    public int currentLap = 0;

    void OnEnable()
    {
        CheckpointManager.RacerCrossedStartingLine += UpdateCurrentLap;
        
    }
    void OnDisable()
    {
        CheckpointManager.RacerCrossedStartingLine -= UpdateCurrentLap;
    }

    void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();

        EventManager.OnTimerStart();
        EventManager.OnLapUpdate(currentLap);
        Debug.Log("Race Gamemode initialized!");
        //Set the base values for the gamemode
        //Trigger any effects that need to be triggered

        
    }


    public void UpdateCurrentLap(Racer racer)
    {
        //Change the current lap text
        //Invoke method of the canvas 
        currentLap++;
        Debug.Log("Current lap is:" + currentLap );
        EventManager.OnLapUpdate(currentLap);
    }
}
