using UnityEngine;
using System.Collections;
using System;

public class SimpleTimer: MonoBehaviour 
{
    /*Create a simple timer with a duration in seconds*/
    public SimpleTimer (float duration)
    {
        targetTime = duration;
    }
    public Action<SimpleTimer> OnTimerStopped;

    public float targetTime = 60.0f;

    void Update(){

    targetTime -= Time.deltaTime;

    if (targetTime <= 0.0f)
    {
       TimerEnded();
    }

    }

    void TimerEnded()
    {
        Debug.Log("Timer has ended");
        OnTimerStopped.Invoke(this);
        Destroy(this);
    }


}