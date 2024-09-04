using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    public enum Axel
    {
        Front,
        Rear
    }

    //Add more breakdowns of the vehicle as their own scripts

    //Wheels
    //Chassis
    //Weapon

    public CarStats carStats;

    public float maxAcceleration = 100f;
    public float brakeAcceleration = 50.0f;

    //These values are modified by the HANDLING stat of the vehicle
    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;




}
