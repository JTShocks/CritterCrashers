using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public event Action<Gamemode> ChangeGamemode;
    //This is the game manager. It is very important.

    //Store a reference to the current game state
    //InRace, InMenu, etc
    //Paused, Running, etc

    //The game manager will manage the moving between scenes and the firing of given events

    Gamemode currentGamemode;

    protected override void Awake()
    {
        base.Awake();
        OnChooseGamemode(0);
        currentGamemode.Initialize();
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    void ChangeScene(string sceneToLoad)
    {
        //Function to change to a new scene.
        //Fade to loading screen when needed.

        SceneManager.LoadScene(sceneToLoad);
    }

    void OnChooseGamemode(int choice)
    {
        switch(choice)
        {
            case 0:
            currentGamemode = new GM_Race();
            break;
        }
    }

    public enum GameState{
        InRace,
        InMenu,
        StartOfRace,
        EndOfRace
    }
}
