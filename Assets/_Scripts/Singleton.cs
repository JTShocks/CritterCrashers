using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance {get; private set;}

    protected virtual void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this as T;
            DontDestroyOnLoad(this);
        }
    }
}
