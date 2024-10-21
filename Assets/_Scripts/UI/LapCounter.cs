using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LapCounter : MonoBehaviour
{
    private TMP_Text lapText;


    void OnEnable()
    {
        EventManager.LapUpdate += OnUpdateLap;
    }
    void OnDisable()
    {
        EventManager.LapUpdate -= OnUpdateLap;
    }

    void Awake()
    {
        lapText = GetComponent<TMP_Text>();
    }

    private void OnUpdateLap(int obj)
    {
        lapText.text = obj.ToString(@"0 /" + GM_Race.TOTAL_LAPS.ToString());
    }
}
