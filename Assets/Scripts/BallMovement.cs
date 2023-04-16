using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;
    private InputAction joystickInput;

    void Start()
{
    // Get a reference to the joystick input action
    joystickInput = new InputAction("move", InputActionType.Value, "<XRController>{LeftHand}/leftStick");
    joystickInput.Enable();
    joystickInput.performed += HandleJoystickInput;
}


    void OnEnable()
    {
        joystickInput.performed += HandleJoystickInput;
    }

    void OnDisable()
    {
        joystickInput.performed -= HandleJoystickInput;
    }

    private void HandleJoystickInput(InputAction.CallbackContext context)
{
    // Get the value of the joystick movement input
    Vector2 joystickValue = context.ReadValue<Vector2>();
    
    // Update the velocity of the ball based on the joystick input
    Vector3 movement = new Vector3(joystickValue.x, 0, joystickValue.y);
    GetComponent<Rigidbody>().AddForce(movement * speed);
}
}

