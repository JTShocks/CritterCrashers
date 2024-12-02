using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{

    public string storedSceneToLoad;
    public event Action<Gamemode> ChangeGamemode;

    [SerializeField] TextMeshPro resultText;

    public GameObject playerModel;
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
        EventManager.OnTimerStop();
        StartCoroutine(ShowResults(didWin));
        ChangeScene("MainMenu");

    }

    public void SetStoredScene(string scene)
    {
        storedSceneToLoad = scene;
    }
    public void AssignPlayerModel(GameObject model)
    {
        playerModel = model;
    }

    IEnumerator ShowResults(bool didWin)
    {
        //Show the text win or lose

        if(didWin)
        {
            resultText.text = "You Win!!!";
        }
        else
        {
            resultText.text = "You Lose!!!";
        }

        //Show the final time on the timer
        yield return new WaitForSeconds(5);
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
