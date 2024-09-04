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
    [SerializeField] LayerMask whatIsGround;

    [SerializeField] bool isGrounded;

    float maxSpeed;

    public List<Transform> rayPoints;
    public float groundRayLength = 2;
    

    void Awake()
    {
        carRb = GetComponent<Rigidbody>();

    }
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");

        transform.position = carRb.transform.position;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, steerInput * vehicle.turnSensitivity* vehicle.carStats.turnStrength * Time.deltaTime, 0f));
    }

    void FixedUpdate()
    {
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
            if(Mathf.Abs(moveInput * vehicle.maxAcceleration) > 0)
            {
                carRb.AddForce(transform.forward * moveInput *vehicle.maxAcceleration * 1000);

            }

        }

        if(carRb.velocity.magnitude > vehicle.carStats.topSpeed)
        {
            carRb.velocity = Vector3.ClampMagnitude(carRb.velocity, vehicle.carStats.topSpeed);
        }
        
    }

    public void Steer()
    {
        var steerAngle = steerInput * vehicle.turnSensitivity *vehicle.maxSteerAngle;
        //carRb.rotation = Quaternion.Euler(0, steerAngle, 0);
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
                transform.rotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
            }
                                        

        }

    }
}
