using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 inputVector;

    public CarController car;


   // #if UNITY_ANDROID
    private PlayerTouchMovement playerTouchMovement;
    //#endif

    // Start is called before the first frame update
    void Awake()
    {
       // #if UNITY_ANDROID
            playerTouchMovement = GetComponent<PlayerTouchMovement>();
        //#endif

    }

    // Update is called once per frame
    void Update()
    {

        //#if UNITY_ANDROID
        //Only in the Android build, should the player input component be read

        inputVector = new Vector3(playerTouchMovement.movementAmount.x, 0, playerTouchMovement.movementAmount.y);
        inputVector.Normalize();
                car.Steer(inputVector);

        //#endif
        
    }

    void FixedUpdate()
    {
        car.Move(inputVector);


    }
}
