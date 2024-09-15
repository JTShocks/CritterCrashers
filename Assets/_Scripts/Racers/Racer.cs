using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{

    //A common class for all racers that stores their information and component references
    //A racer stores data for the next checkpoint it needs to reach to progress

    //The RaceManager tracks all the current racers positions

    //Track length calculated by taking all the checkpoints and comparing them
    //Racer position is finding it's distance from where it is in relation to the next checkpoint
    //Racer with the currentCheckpoint


    //The current checkpoint for the racer
    public Checkpoint nextCheckpoint;


    public int currentLap;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetNextCheckpoint(Checkpoint checkpoint)
    {
        nextCheckpoint = checkpoint;
    }
}
