using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeSelector : MonoBehaviour
{
    public void SetStoredScene(string scene)
    {
        GameManager.Instance.SetStoredScene(scene);
    }
}
