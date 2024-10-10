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

    [SerializeField]
    public Gamemode currentGamemode;


    protected override void Awake()
    {
        base.Awake();
        
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

    void OnChooseGamemode(Gamemode gamemode)
    {

    }

    public enum GameState{
        InRace,
        InMenu,
        StartOfRace,
        EndOfRace
    }
}
