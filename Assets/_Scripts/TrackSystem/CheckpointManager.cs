using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public static CheckpointManager instance {get; private set;}
    // Keeps track of all the checkpoints and knows when one is crossed
    // Establishes their ID order when a race starts



    //Starting line is checkpoint at ID 0
    
    private LinkedList<Checkpoint> checkpoints = new();

    public static event Action<Racer> RacerCrossedStartingLine = delegate {};

    // Start is called before the first frame update
    void OnEnable()
    {
        var children = GetComponentsInChildren<Checkpoint>();
        checkpoints.AddFirst(children[0]);

        Debug.Log(children[0].name);
        LinkedListNode<Checkpoint> current = checkpoints.First;
        foreach(Checkpoint checkpoint in children)
        {
            if(!checkpoints.Contains(checkpoint))
            {
                checkpoints.AddAfter(current, checkpoint);
                current = current.Next;
                
            }
            checkpoint.RacerCrossedCheckpoint += OnRacerCrossCheckpoint;


        }
    }
    void OnDisable()
    {
        foreach(Checkpoint checkpoint in checkpoints)
        {
            checkpoint.RacerCrossedCheckpoint -= OnRacerCrossCheckpoint;
        }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    //Controls setting the next checkpoint for a racer and determining what happens next
    void OnRacerCrossCheckpoint(Racer racer, Checkpoint checkpoint)
    {
        //Make sure the player cannot cross irrelevant checkpoints
        var racerCurrent = checkpoints.Find(racer.nextCheckpoint);
        var currentCheckpoint = checkpoints.Find(checkpoint);

        if(currentCheckpoint != racerCurrent)
        {
            Debug.Log("Crossed invalid checkpoint");
            return;
        }
        var nextCheckpoint = checkpoints.Find(checkpoint).Next;
        //Determine if the player crossed the starting line
        if(checkpoints.First.Value == checkpoint)
        {            
            Debug.Log("Racer crossed starting line");
            //Send out the event and who crossed it
            RacerCrossedStartingLine(racer);
            //Always assign the next checkpoint as the one after the first
            nextCheckpoint = checkpoints.First.Next;

        }

        //Find the next checkpoint for the racer in their current position
        
        //Check if the checkpoint they crossed is the LAST checkpoint
        if(nextCheckpoint == null)
        {
            Debug.Log("Next checkpoint returned null");
            //Set the racer's current checkpoint to the FIRST checkpoint
            nextCheckpoint = checkpoints.First;
        }
        //Set racer checkpoint to the next one in the list
        racer.SetNextCheckpoint(nextCheckpoint.Value);
        
        Debug.Log("Next checkpoint is:" + racer.nextCheckpoint.name);
    }
}
