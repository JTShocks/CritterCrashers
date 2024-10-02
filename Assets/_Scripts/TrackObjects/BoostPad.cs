using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BoxCollider))]
public class BoostPad : MonoBehaviour
{

    public BoxCollider box;
    public float boostDuration;

    public bool showDebug;

    void Awake()
    {
       // box = GetComponent<BoxCollider>();
    }
    void OnTriggerEnter(Collider collider)
    {
        Racer racer = collider.gameObject.GetComponent<Racer>();
        
        if(racer != null)
        {
            //Apply the boost effect

            racer.controller.ApplyBoost(boostDuration);
        }
        
    }

    void OnDrawGizmos()
    {
        if(showDebug)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(box.center, box.size);

        }

    }
}
