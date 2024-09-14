using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public int checkpointID;
    public Checkpoint nextCheckpoint;

    //Create a struct to store the given information of a checkpoint
    //Use a linked list to determine the order of given checkpoint data

    public event Action<Racer, Checkpoint> RacerCrossedCheckpoint;

    void OnTriggerEnter(Collider collider)
    {
        //When a racer crosses a checkpoint
        Racer racer = collider.gameObject.GetComponent<Racer>();
        if(racer != null)
        {
            //Send a signal a racer crossed a checkpoint
            RacerCrossedCheckpoint.Invoke(racer, this);
        }


    }
}
