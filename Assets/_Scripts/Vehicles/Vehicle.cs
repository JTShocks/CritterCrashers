using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{

    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    public List<Wheel> Wheels;

    //Add more breakdowns of the vehicle as their own scripts

    //Wheels
    //Chassis
    //Weapon

    //Vehicle Stats

    //These two values make up the ACCELERATION stat for a vehicle
    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    //These values are modified by the HANDLING stat of the vehicle
    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;



}
