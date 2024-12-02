using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNewGameButton : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.ChangeScene();
    }
}
