using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemode : MonoBehaviour
{
    public static Action<bool> GameWin;



    //Initialize the gamemode on the current track, grabbing all the data for the track and the checkpoints

    //For example: A Time attack gamemode connects to the Checkpoint crossed event, by adding time
    //The gamemode also determines if the game should spawn in other AI racers

    //Gamemode is a base class for all other gamemodes
    //When a gamemode is loaded, it is initialized with all the requirements required of it
    public virtual void Initialize()
    {
        Debug.Log("Gamemode is initializing...");
    }


    




}
