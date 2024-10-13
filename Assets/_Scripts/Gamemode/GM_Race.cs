using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Race : Gamemode
{
    const int TOTAL_LAPS = 3;

    public int currentLap = 1;

    


    void OnEnable()
    {
        CheckpointManager.RacerCrossedStartingLine += UpdateCurrentLap;
    }

    public override void Initialize()
    {
        base.Initialize();
        //Set the base values for the gamemode
        //Trigger any effects that need to be triggered

        
    }


    public void UpdateCurrentLap(Racer racer)
    {

    }
}
