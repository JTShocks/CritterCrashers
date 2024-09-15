using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    // Keeps track of all the checkpoints and knows when one is crossed
    // Establishes their ID order when a race starts



    //Starting line is checkpoint at ID 0
    
    private LinkedList<Checkpoint> checkpoints = new();

    public static event Action<Racer> RacerCrossedStartingLine;

    // Start is called before the first frame update
    void OnEnable()
    {
        var children = GetComponentsInChildren<Checkpoint>();

        checkpoints.AddFirst(children[0]);
        LinkedListNode<Checkpoint> current = checkpoints.First;
        foreach(Checkpoint checkpoint in children)
        {
            checkpoints.AddAfter(current, checkpoint);
            current = current.Next;
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

    //Controls setting the next checkpoint for a racer and determining what happens next
    void OnRacerCrossCheckpoint(Racer racer, Checkpoint checkpoint)
    {
        //Determine if the player crossed the starting line
        if(checkpoints.First.Value == checkpoint)
        {
            //Send out the event and who crossed it
            RacerCrossedStartingLine.Invoke(racer);
        }

        //Find the next checkpoint for the racer in their current position
        var nextCheckpoint = checkpoints.Find(checkpoint).Next;
        //Check if the checkpoint they crossed is the LAST checkpoint
        if(nextCheckpoint == null)
        {
            //Set the racer's current checkpoint to the FIRST checkpoint
            racer.currentCheckpoint = checkpoints.First.Value;
        }
        else
        {
            //Set racer checkpoint to the next one in the list
            racer.currentCheckpoint = nextCheckpoint.Value;
        }
    }
}
