using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //This is the game manager. It is very important.

    //Store a reference to the current game state
    //InRace, InMenu, etc
    //Paused, Running, etc

    //The game manager will manage the moving between scenes and the firing of given events


    protected override void Awake()
    {
        base.Awake();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
