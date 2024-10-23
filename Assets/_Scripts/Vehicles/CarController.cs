using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CarController : MonoBehaviour
{

    public Vehicle vehicle;

    [SerializeField] Rigidbody carRb;

    [SerializeField]
    public UnityEvent OnBoostActivated;

    float moveInput;
    float steerInput;

    bool isBoosted;
    const float BOOST_STRENGTH = 5;

    public float DownForceValue = 100.0f;

    [SerializeField] private float KPH;
    [SerializeField] LayerMask whatIsGround;

    [SerializeField] bool isGrounded;

    float maxSpeed;

    public List<Transform> rayPoints;
    public float groundRayLength = 2;

    public float carTopSpeed;
    float gravityForce = 10f;

    [SerializeField] GameObject dustVFX;

    

    void Awake()
    {        
        carTopSpeed = vehicle.carStats.topSpeed;
        Debug.Log(carTopSpeed);
        Racer racer = carRb.GetComponent<Racer>();
        racer.controller = this;
        carRb.transform.parent = null;


    }
    void Update()
    {
        transform.position = carRb.transform.position;
        dustVFX.SetActive(isGrounded && carRb.velocity.magnitude > 10);
    }

    void FixedUpdate()
    {
        isGrounded = false;
        CheckIsGrounded();
        //Move();
        //Steer(new Vector3(Input.GetAxis("Horizontal"), 0, 0));
        AddDownForce();
        if(!isBoosted)
        {
            if(carRb.velocity.magnitude > carTopSpeed)
            {
                
                carRb.velocity = Vector3.ClampMagnitude(carRb.velocity, carTopSpeed);
            }
        }
        else
        {
            carRb.velocity = carRb.velocity.normalized * (carTopSpeed+BOOST_STRENGTH);
        }



    }

    //All users use this to move the vehicle they are controlling
    public void Move(Vector3 moveInput)
    {
        //KPH calculation
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
            carRb.AddForce(Vector3.up * -gravityForce * 100f);

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

    public void ApplyBoost(float duration)
    {
        var timer = this.AddComponent<SimpleTimer>();
        timer.targetTime = duration;
        timer.OnTimerStopped += CancelBoost;
        //carTopSpeed += 50;
        isBoosted = true;
        OnBoostActivated.Invoke();
        
    }
    public void CancelBoost(SimpleTimer timer)
    {
        timer.OnTimerStopped -= CancelBoost;
        //carTopSpeed -= 50;
        isBoosted = false;
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
