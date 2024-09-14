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
        transform.position = carRb.transform.position;
    }

    void FixedUpdate()
    {
        isGrounded = false;
        CheckIsGrounded();
        //Move();
        //Steer(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
        AddDownForce();
    }

    //All users use this to move the vehicle they are controlling
    public void Move(Vector3 moveInput)
    {
        
        KPH = carRb.velocity.magnitude * 3.6f;
        if(isGrounded)
        {
            carRb.drag = 2;
            if(Mathf.Abs(moveInput.z * vehicle.maxAcceleration) > 0)
            {
                carRb.AddForce(transform.forward * moveInput.z *vehicle.maxAcceleration * 1000);

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

    public void Steer(Vector3 steerInput)
    {

        var steerAngle = steerInput.x * vehicle.turnSensitivity *vehicle.maxSteerAngle;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, steerInput.x * vehicle.turnSensitivity* vehicle.carStats.turnStrength*Time.deltaTime * steerInput.z, 0f));
        
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
