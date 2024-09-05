using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public Vehicle vehicle;

    [SerializeField] Rigidbody carRb;

    float moveInput;
    float steerInput;

    public float DownForceValue = 50.0f;

    [SerializeField] private float KPH;
    [SerializeField] LayerMask whatIsGround;

    [SerializeField] bool isGrounded;

    float maxSpeed;

    public List<Transform> rayPoints;
    public float groundRayLength = 2;
    

    void Awake()
    {
        carRb.transform.parent = null;

    }
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");

        //transform.position = carRb.transform.position;

        

        
    }

    void FixedUpdate()
    {
        isGrounded = false;
        CheckIsGrounded();
        Move();
        Steer();
        AddDownForce();
    }

    //All users use this to move the vehicle they are controlling
    public void Move()
    {
        
        KPH = carRb.velocity.magnitude * 3.6f;
        if(isGrounded)
        {
            carRb.drag = 2;
            if(Mathf.Abs(moveInput * vehicle.maxAcceleration) > 0)
            {
                carRb.AddForce(transform.forward * moveInput *vehicle.maxAcceleration * 1000);

            }

        }
        else
        {
            carRb.drag = 0.1f;
        }

        if(carRb.velocity.magnitude > vehicle.carStats.topSpeed)
        {
            carRb.velocity = Vector3.ClampMagnitude(carRb.velocity, vehicle.carStats.topSpeed);
        }
        
    }

    public void Steer()
    {
        var steerAngle = steerInput * vehicle.turnSensitivity *vehicle.maxSteerAngle;
        carRb.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, steerInput * vehicle.turnSensitivity* vehicle.carStats.turnStrength*Time.fixedDeltaTime, 0f)));
        
    }
    void AddDownForce()
    {
        if(isGrounded)
        {
            carRb.AddForce(-transform.up * DownForceValue * carRb.velocity.magnitude);
        }

    }

    void CheckIsGrounded()
    {
        RaycastHit hit;
        Vector3 groundNormal = Vector3.zero;
        foreach(Transform point in rayPoints)
        {
            if(Physics.Raycast(point.position, -transform.up, out hit, groundRayLength, whatIsGround))
            {
                isGrounded = true;

                groundNormal += hit.normal;
                carRb.MoveRotation(Quaternion.FromToRotation(transform.up, groundNormal) * carRb.rotation);
            }
                                        

        }

    }
}
