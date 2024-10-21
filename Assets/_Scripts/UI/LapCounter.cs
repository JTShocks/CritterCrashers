using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LapCounter : MonoBehaviour
{
    private TMP_Text lapText;

    public static Action<int> UpdateLap;


    void OnEnable()
    {
        UpdateLap += OnUpdateLap;
    }
    void OnDisable()
    {
        UpdateLap -= OnUpdateLap;
    }

    private void OnUpdateLap(int obj)
    {
        lapText.text = obj.ToString(@"0 /" + GM_Race.TOTAL_LAPS.ToString());
    }
}
