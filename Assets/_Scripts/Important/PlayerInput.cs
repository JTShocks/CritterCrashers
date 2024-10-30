using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, PlayerControls.IKeyboardActions
{

    private PlayerControls playerControls;
    public static UnityAction onShoot = delegate { };
    public static UnityAction onDrift = delegate { };
    public static UnityAction<Vector2> onMove = delegate { };
    void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.Keyboard.SetCallbacks(this);
        }
        playerControls.Keyboard.Enable();
    }

    void OnDisable()
    {
        playerControls.Keyboard.Disable();
    }
    public void OnDrift(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            onDrift();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        onMove(context.ReadValue<Vector2>());
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("Shoot");
    }


}
