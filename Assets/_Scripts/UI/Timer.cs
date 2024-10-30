
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    private TMP_Text timerText;
    enum TimerType{Countdown, Stopwatch}

    [SerializeField] private TimerType timerType;
    [SerializeField] private float timeToDisplay = 60.0f;
    private bool isRunning;

    private void Awake()
    {
        timerText = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        EventManager.TimerStart += EventManagerOnTimerStart;
        EventManager.TimerStop += EventManagerOnTimerStop;
        EventManager.TimerUpdate += EventManagerOnTimerUpdate;
    }

    void OnDisable()
    {
        EventManager.TimerStart -= EventManagerOnTimerStart;
        EventManager.TimerStop -= EventManagerOnTimerStop;
        EventManager.TimerUpdate -= EventManagerOnTimerUpdate;
    }

    private void EventManagerOnTimerUpdate(float value) => timeToDisplay += value;
    private void EventManagerOnTimerStop() => isRunning = false;
    private void EventManagerOnTimerStart() => isRunning = true;


    // Update is called once per frame
    void Update()
    {

        if(!isRunning)
        {
            return;
        }

        if(timerType == TimerType.Countdown && timeToDisplay < 0.0f)
        {
            //EventManager.OnTimerStop();
            return;
        }

        timeToDisplay += timerType == TimerType.Countdown ? -Time.deltaTime : Time.deltaTime;

        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = timeSpan.ToString(@"mm\:ss\:ff");
    }
}
