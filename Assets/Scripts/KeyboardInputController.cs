using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInputController : MonoBehaviour
{
    public float speed = 0;
    public float rotationSpeed = 0;
    public InputActionProperty resetButton;

    
    private Vector3 initialPosition;
    private Rigidbody rb;
    private Camera mainCamera;
    private float movementX;
    private float movementY;
    private float resetButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        initialPosition = transform.position;
    }

    // FixedUpdate updates the value of the rigid body, to apply force to the ball
    void FixedUpdate() 
    {
        // Calculate the camera-relative movement vector
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;
        Vector3 cameraRelativeMovement = movementX * cameraRight + movementY * cameraForward;
        
        // Apply the movement to the ball
        rb.AddForce(cameraRelativeMovement * speed);

        // Rotate the ball to face the camera direction
        Quaternion targetRotation = Quaternion.LookRotation(mainCamera.transform.forward);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));

    }

    // OnMove will read the inputs when pressed
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

        // If the user is only inputting a direction in the X or Y axis, but not both, force the other direction to be zero.
        if (movementX != 0 && movementY == 0)
        {
            movementY = Mathf.Sign(movementX) * Mathf.Abs(movementX);
        }
        else if (movementY != 0 && movementX == 0)
        {
            movementX = Mathf.Sign(movementY) * Mathf.Abs(movementY);
        }
    }

    // On reset button pressed, sends player to origin with 0 movement
    void OnReset(InputValue resetValue){
        
        // Resets position to origin
        transform.position = initialPosition;
        
        //Stop Moving/Translating
        rb.velocity = Vector3.zero;

        //Stop rotating
        rb.angularVelocity = Vector3.zero;
    }

    // Just an example function for now. Only works with Trigger and Grip for some reason
    void OnLeftPrimaryValue(InputValue resetButValue){
        Debug.Log("Reset value");
        Debug.Log(resetButValue);
    }
}