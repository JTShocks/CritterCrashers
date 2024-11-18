using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public string storedSceneToLoad;
    public event Action<Gamemode> ChangeGamemode;

    GameObject playerModel;
    //This is the game manager. It is very important.

    void OnEnable()
    {
        Gamemode.GameFinish += OnGameFinish;
    }

    void OnDisable()
    {
        Gamemode.GameFinish -= OnGameFinish;
    }

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

    void OnGameFinish(bool didWin)
    {

        if(!didWin)
        {
            ChangeScene("MainMenu");
        }

    }

    public void SetStoredScene(string scene)
    {
        storedSceneToLoad = scene;
    }
    public void AssignPlayerModel(GameObject model)
    {
        playerModel = model;
    }



    public void ChangeScene(string sceneToLoad)
    {
        //Function to change to a new scene.
        //Fade to loading screen when needed.

        SceneManager.LoadScene(sceneToLoad);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(storedSceneToLoad);
    }

    void OnChooseGamemode(int choice)
    {
        switch(choice)
        {
            case 0:

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
