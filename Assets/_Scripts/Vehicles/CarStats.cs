using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "CarStats", menuName = "CarStats")]
public class CarStats : ScriptableObject
{
    public CarStats(){}

    [Header("Acceleration")]
    [Tooltip("Rate at which the car increases forward speed")]
    public VehicleStat Acceleration;
    
    [Header("Speed")]
    [Tooltip("Value of the vehicle speed stat")]
    public VehicleStat Speed;

    public float minimumSpeed;
    public float topSpeed;
    public float maximumTopSpeed;
    public float reverseSpeed;

    [Header("Drag")]
    public float groundDrag;

    public VehicleStat Handling;

    public float turnStrength = 180;
    public VehicleStat OffRoading;
    [Tooltip("Determines which car bounces off another in a collision")]
    public VehicleStat Weight;
}
