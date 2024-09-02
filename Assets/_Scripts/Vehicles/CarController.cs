using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{

    public Vehicle vehicle;

    private Rigidbody carRb;

    float moveInput;
    float steerInput;

    public float DownForceValue = 50.0f;

    [SerializeField] private float KPH;

    bool isGrounded;

    float maxSpeed;
    

    void Awake()
    {
        carRb = GetComponent<Rigidbody>();
        maxSpeed = 10 * vehicle.Speed.Value;

    }
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Move();
        Steer();
        AddDownForce();
    }

    //All users use this to move the vehicle they are controlling
    public void Move()
    {
        foreach(var wheel in vehicle.Wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * vehicle.maxAcceleration;
        }
        KPH = carRb.velocity.magnitude * 3.6f;

        if(carRb.velocity.magnitude > maxSpeed)
        {
            carRb.velocity = Vector3.ClampMagnitude(carRb.velocity, maxSpeed);
        }
        
    }

    public void Steer()
    {
        foreach(var wheel in vehicle.Wheels)
        {
            if(wheel.axel == Vehicle.Axel.Front)
            {
                var steerAngle = steerInput * vehicle.turnSensitivity *vehicle.maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, steerAngle, 0.6f);
            }
        }
    }
    void AddDownForce()
    {
        carRb.AddForce(-transform.up * DownForceValue * carRb.velocity.magnitude);
    }
}
