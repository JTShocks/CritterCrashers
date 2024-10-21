using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class GM_Race : Gamemode
{
    const int TOTAL_LAPS = 3;

    public int currentLap = 0;






    void OnEnable()
    {
        //CheckpointManager.RacerCrossedStartingLine += UpdateCurrentLap;
    }
    void OnDisable()
    {
        CheckpointManager.RacerCrossedStartingLine -= UpdateCurrentLap;
    }

    public override void Initialize()
    {
        base.Initialize();
        CheckpointManager.RacerCrossedStartingLine += UpdateCurrentLap;
        Timer raceTimer = new Timer(){
            Interval = 1000,
            Enabled = true,
            AutoReset = true,

        };
        Debug.Log("Race Gamemoe initialized!");
        //Set the base values for the gamemode
        //Trigger any effects that need to be triggered

        
    }


    public void UpdateCurrentLap(Racer racer)
    {
        //Change the current lap text
        //Invoke method of the canvas 
        currentLap++;
        Debug.Log("Current lap is:" + currentLap );
    }
}
