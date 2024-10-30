using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    private Vector3 inputVector;

    public CarController car;

    [SerializeField]
    public UnityEvent OnStartMove;
    [SerializeField]
    public UnityEvent OnStopMove;



    bool isMoving;
    
    #if UNITY_ANDROID
    private PlayerTouchMovement playerTouchMovement;
    #endif

    void OnEnable()
    {
        PlayerInput.onMove += MovementInput;
        
    }

    void OnDisable()
    {
        PlayerInput.onMove -= MovementInput;
    }

    // Start is called before the first frame update
    void Awake()
    {
        #if UNITY_ANDROID
            playerTouchMovement = GetComponent<PlayerTouchMovement>();
        #endif

    }

    // Update is called once per frame
    void Update()
    {
        #if UNITY_ANDROID
        //Only in the Android build, should the player input component be read
           MovementInput(playerTouchMovement.movementAmount);
        #endif


        
        car.Steer(inputVector);

        if(inputVector.magnitude > 0 && !isMoving)
        {
            isMoving = true;
            OnStartMove?.Invoke();
        }
        else if(Mathf.Approximately(inputVector.magnitude, 0) && isMoving)
        {
            isMoving = false;
            OnStopMove?.Invoke();
        }
        


        
    }

    void MovementInput(Vector2 input)
    {
        inputVector = new Vector3(input.x, 0, input.y);
        inputVector.Normalize();





    }

    void FixedUpdate()
    {
        car.Move(inputVector);
    }
}
