using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinText : MonoBehaviour
{
    public TMP_Text resultText;

    void OnEnable()
    {
        Gamemode.GameFinish += SetResultText;
    }

    void OnDisable()
    {
        Gamemode.GameFinish -= SetResultText;
    }


    public void SetResultText(bool didWin)
    {

        if(didWin)
        {
            resultText.text = "You Win!!!";
        }
        else
        {
            resultText.text = "You Lose!!!";
        }
        
    }
}
