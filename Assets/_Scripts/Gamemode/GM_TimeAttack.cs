using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_TimeAttack : Gamemode
{

    const int TIME_PER_CHECKPOINT = 2;
    void OnEnable()
    {
        CheckpointManager.RacerAdvanced += AddRaceTime;
        EventManager.TimerStop += FinishGame;
        
    }



    void OnDisable()
    {
        CheckpointManager.RacerAdvanced -= AddRaceTime;
        EventManager.TimerStop -= FinishGame;
        
    }

    void Start()
    {
        Initialize();
    }
    private void FinishGame()
    {
        GameWin?.Invoke(false);
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
        EventManager.OnTimerUpdate(TIME_PER_CHECKPOINT);
    }
}
