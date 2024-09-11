using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerTouchMovement : MonoBehaviour
{

    [SerializeField]
    private Vector2 joystickSize = new Vector2(300,300);
    [SerializeField]
    private FloatingJoystick Joystick;
    [SerializeField]
    private PlayerController Player;

    private Finger movementFinger;
    private Vector2 movementAmount; 

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleFingerUp;
        ETouch.Touch.onFingerMove += HandleFingerMove;
    }

    void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleFingerUp;
        ETouch.Touch.onFingerMove += HandleFingerMove;
        EnhancedTouchSupport.Disable();
    }
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void HandleFingerMove(Finger touchedFinger)
    {
        
    }
    private void HandleFingerUp(Finger touchedFinger)
    {
        
    }

    private void HandleFingerDown(Finger touchedFinger)
    {
        if(movementFinger == null && touchedFinger.screenPosition.x <= Screen.width /2f)
        {
            movementFinger = touchedFinger;
            movementAmount = Vector2.zero;
            Joystick.gameObject.SetActive(true);
            Joystick.RectTransform.sizeDelta = joystickSize;
            Joystick.RectTransform.anchoredPosition = ClampStartPosition(touchedFinger.screenPosition);

        }
    }

    private Vector2 ClampStartPosition(Vector2 startPosition)
    {
        if(startPosition.x < joystickSize.x /2)
        {
            startPosition.x = joystickSize.x / 2;
        }

        if(startPosition.y < joystickSize.y / 2)
        {
            startPosition.y = joystickSize.y / 2;
        }
        else if(startPosition.y > Screen.height - joystickSize.y/2)
        {
            startPosition.y = Screen.height - joystickSize.y / 2;
        }

        return startPosition;
    }
}
