using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    // Keeps track of all the checkpoints and knows when one is crossed
    // Establishes their ID order when a race starts



    //Starting line is checkpoint at ID 0
    
    private LinkedList<Checkpoint> checkpoints = new();

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



    // Update is called once per frame
    void Update()
    {
        
    }

    void OnRacerCrossCheckpoint(Racer racer, Checkpoint checkpoint)
    {
        //Update the racer's current checkpoints

        var nextCheckpoint = checkpoints.Find(checkpoint).Next;
        racer.currentCheckpoint = nextCheckpoint.Value;
    }
}
